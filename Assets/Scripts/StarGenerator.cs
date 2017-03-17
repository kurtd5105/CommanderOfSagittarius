using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StarGenerator : MonoBehaviour {
    // TODO: Make these get set based on player count/map size
    public const int homeworlds = 4;
    public const int startypes = 6;
    public const int quadrants = 4;
    public const int columns = 12;
    public const int rows = 12;

    /* 
     * Stars: A list of the game stars to instantiate.
     * The stars are required to be in the following order:
     * 1. Yellow
     * 2. Red
     * 3. Green
     * 4. Blue
     * 5. Purple
     * 6. White
     */
    public GameObject[] stars;
    public SortedDictionary<StarColor, GameObject> starColorToGameObject;

    // Pairs containing all the owners and their race.
    // TODO: Make these get set based on player choice + random chance for AI
    public KeyValuePair<Owners, Races>[] activePlayers;

    // List of all the generated stars.
    public List<GameObject> generatedStars;

    // Parent transforms for generated stars.
    private Transform starmap;
    private Transform homeworldParent;

    // Holds all remaining locations that a star can be placed in.
    private List<KeyValuePair<int, int>>[] locationsAvailable;

    // Holds the coordinates of each quadrant.
    private KeyValuePair<int, int>[] quadrantLocations;

    //Data for weighted random.
    private int r = 0;
    private KeyValuePair<StarColor, int>[] starWeights;

    void Initialize() {
        starmap =         new GameObject("Starmap").transform;
        homeworldParent = new GameObject("Homeworlds").transform;

        activePlayers =    new KeyValuePair<Owners, Races>[homeworlds];
        activePlayers[0] = new KeyValuePair<Owners, Races>(Owners.PLAYER, Races.HUMAN);
        activePlayers[1] = new KeyValuePair<Owners, Races>(Owners.AI1, Races.CRYSTALS);
        activePlayers[2] = new KeyValuePair<Owners, Races>(Owners.AI2, Races.CYBORG);
        activePlayers[3] = new KeyValuePair<Owners, Races>(Owners.AI3, Races.LIZARDPEOPLE);

        starColorToGameObject = new SortedDictionary<StarColor, GameObject>();
        starColorToGameObject.Add(StarColor.YELLOW, stars[0]);
        starColorToGameObject.Add(StarColor.RED, stars[1]);
        starColorToGameObject.Add(StarColor.GREEN, stars[2]);
        starColorToGameObject.Add(StarColor.BLUE, stars[3]);
        starColorToGameObject.Add(StarColor.PURPLE, stars[4]);
        starColorToGameObject.Add(StarColor.WHITE, stars[5]);

        // Generate and setup star weights.
        setupWeight();

        InitializeLists();
    }
    void InitializeLists() {
        // TODO: change fixed square size.
        // Set up the quadrant locations.
        quadrantLocations = new KeyValuePair<int, int>[quadrants];
        int i = 0;
        for (int x = 0; x < 2; x++) {
            for (int y = 0; y < 2; y++) {
                quadrantLocations[i] = new KeyValuePair<int, int>(x, y);
                i++;
            }
        }

        // Setup available locations.
        locationsAvailable = new List<KeyValuePair<int, int>>[quadrants];
        for (int q = 0; q < quadrants; q++) {
            locationsAvailable[q] = new List<KeyValuePair<int, int>>();
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < columns; y++) {
                    locationsAvailable[q].Add(new KeyValuePair<int, int>(x, y));
                }
            }
        }
    }

    void SetupHomeworlds() {
        for (int i = 0; i < homeworlds; i++) {
            CreateNewStar(i, 0, stars[0]);
            generatedStars[i].transform.localScale = new Vector3(5f, 5f, 5f);
            generatedStars[i].transform.SetParent(homeworldParent);
            generatedStars[i].GetComponent<StarProperties>().Generate(StarColor.YELLOW, true);
            generatedStars[i].GetComponent<StarProperties>().owner = activePlayers[i].Key;
        }
        // TODO: Setup homeworld properties here.
    }

    void StarmapSetup() {
        // Generates stars, one by one cycling through each quadrant.
        bool hasCountChanged = true;
        while (hasCountChanged) {
            hasCountChanged = false;

            for (int q = 0; q < quadrants; q++) {
                if (locationsAvailable[q].Count > 0) {
                    hasCountChanged = true;
                    GameObject toInstantiate = GetRandomStarType();
                    CreateNewStar(q, 1, toInstantiate);
                    generatedStars[generatedStars.Count - 1].GetComponent<StarProperties>().Generate(StarColor.YELLOW, false);
                }
            }
        }
    }

    Vector3 RandomPosition(int quadrant, int maxDeviation) {
        int randomIndex = Random.Range(0, locationsAvailable[quadrant].Count);
        KeyValuePair<int, int> coords = locationsAvailable[quadrant][randomIndex];
        Vector3 randomPosition = GetRandomPositionFromCoords(coords, quadrant, maxDeviation);

        // For every quadrant surrounding the current quadrant, including the current quadrant, remove nearby stars.
        for (int qx = quadrantLocations[quadrant].Key - 1; qx <= quadrantLocations[quadrant].Key + 1; qx++) {
            if (qx < 0) {
                continue;
            }

            for (int qy = quadrantLocations[quadrant].Value - 1; qy <= quadrantLocations[quadrant].Value + 1; qy++) {
                if (qy < 0) {
                    continue;
                }

                // Find the index of the current quadrant.
                int q = GetQuadrantIndexFromCoords(qx, qy);

                if (q == -1) {
                    continue;
                }

                RemoveAdjacentQuadrantPositions(coords, quadrant, q, qx, qy);
            }
        }

        return randomPosition;
    }

    Vector3 GetRandomPositionFromCoords(KeyValuePair<int, int> coords, int quadrant, int maxDeviation) {
        return new Vector3(
            coords.Key   + (quadrantLocations[quadrant].Value * rows)  + GetRandomDeviation(maxDeviation), // x
            coords.Value + (quadrantLocations[quadrant].Key * columns) + GetRandomDeviation(maxDeviation), // y
            quadrant // z, unused in 2D game, used for debug
        );
    }

    float GetRandomDeviation(int max) {
        return (Random.Range(0, max * 2 + 1) - max) * 0.1f;
    }

    // Take a quadrant x and y position and get its index.
    int GetQuadrantIndexFromCoords(int x, int y) {
        int q = -1;
        for (int i = 0; i < quadrants; i++) {
            if (quadrantLocations[i].Key == x && quadrantLocations[i].Value == y) {
                q = i;
                break;
            }
        }
        return q;
    }

    // Remove all star positions within a 4 star radius.
    void RemoveAdjacentQuadrantPositions(KeyValuePair<int, int> coords, int quadrant, int q, int qx, int qy) {
        int x, condition;
        if (qx < quadrantLocations[quadrant].Key) {
            x = rows + (coords.Key - 4);
            condition = rows + (coords.Key + 4);
        } else if (qx == quadrantLocations[quadrant].Key) {
            x = coords.Key - 4;
            condition = coords.Key + 4;
        } else {
            x = (coords.Key - 4) - rows;
            condition = (coords.Key + 4) - rows;
        }

        for (; x <= condition; x++) {
            RemoveQuadrantColumns(coords, quadrant, q, qy, x);
        }
    }


    // Remove all stars in a column for a quadrant.
    void RemoveQuadrantColumns(KeyValuePair<int, int> coords, int quadrant, int q, int qy, int x) {
        int y, condition;
        if (qy < quadrantLocations[quadrant].Value) {
            y = columns + (coords.Value - 4);
            condition = columns + (coords.Value + 4);
        } else if (qy == quadrantLocations[quadrant].Value) {
            y = coords.Value - 4;
            condition = coords.Value + 4;
        } else {
            y = (coords.Value - 4) - columns;
            condition = (coords.Value + 4) - columns;
        }

        for (; y <= condition; y++) {
            locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
        }
    }

    void setupWeight() {
        // TODO: Convert to template.
        starWeights = new KeyValuePair<StarColor, int>[startypes];

        // 3 yellow + 4 red + 4 green + 3 blue + 1 purple + 1 white = 16
        starWeights[0] = new KeyValuePair<StarColor, int>(StarColor.YELLOW, 3);
        starWeights[1] = new KeyValuePair<StarColor, int>(StarColor.RED, 4);
        starWeights[2] = new KeyValuePair<StarColor, int>(StarColor.GREEN, 4);
        starWeights[3] = new KeyValuePair<StarColor, int>(StarColor.BLUE, 3);
        starWeights[4] = new KeyValuePair<StarColor, int>(StarColor.PURPLE, 1);
        starWeights[5] = new KeyValuePair<StarColor, int>(StarColor.WHITE, 1);
    }

    GameObject GetRandomStarType() {
        int weight = 0;

        foreach (KeyValuePair<StarColor, int> element in starWeights) {
            weight += element.Value;
        }

        r = Random.Range(1, weight);

        foreach (KeyValuePair<StarColor, int> element in starWeights)
        {
            if (r < element.Value) {
                Debug.Log(element.Key);
                return starColorToGameObject[element.Key];
            }
            r -= element.Value;
        }

        //Should never reach, make a Yellow Star
        Debug.Assert(false);
        return stars[0];
    }

    // Create a star at a random position and remove all possible positions surrounding it.
    void CreateNewStar(int q, int maxDeviation, GameObject toInstantiate) {
        GameObject instance = Instantiate(toInstantiate, RandomPosition(q, maxDeviation), Quaternion.identity) as GameObject;
        instance.transform.localScale = new Vector3(4f, 4f, 4f);
        instance.transform.SetParent(starmap);
        generatedStars.Add(instance);
    }

    public void SetupScene() {
        Initialize();
        SetupHomeworlds();
        // TODO: Add Sagittarius.
        StarmapSetup();
    }
}
