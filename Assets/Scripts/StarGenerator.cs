using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StarGenerator : MonoBehaviour {
    public const int homeworlds = 4;
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
    public List<GameObject> generatedStars;

    private Transform starmap;
    private Transform homeworldParent;
    private List<KeyValuePair<int, int>>[] locationsAvailable;
    private KeyValuePair<int, int>[] quadrantLocations;

    void Initialize() {
        starmap = new GameObject("Starmap").transform;
        homeworldParent = new GameObject("Homeworlds").transform;

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

    GameObject GetRandomStarType() {
        int r = Random.Range(1, 17);

        // TODO: Use an actual distribution
        // 3 yellow + 4 red + 4 green + 3 blue + 1 purple + 1 white = 16
        if (r <= 3) {
            return stars[0];
        } else if (r <= 7) {
            return stars[1];
        } else if (r <= 11) {
            return stars[2];
        } else if (r <= 14) {
            return stars[3];
        } else if (r == 15) {
            return stars[4];
        } else {
            return stars[5];
        }
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
        // TODO: Add Orion.
        StarmapSetup();
    }
}
