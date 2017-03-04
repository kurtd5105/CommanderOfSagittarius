using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StarGenerator : MonoBehaviour {
    public int quadrants = 4;
    public int columns = 12;
    public int rows = 12;
    public GameObject[] stars;

    private Transform starmap;
    private List<KeyValuePair<int, int>>[] locationsAvailable;
    private KeyValuePair<int, int>[] quadrantLocations;

    void InitializeList() {
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

    void StarmapSetup() {
        starmap = new GameObject("Starmap").transform;

        // TODO: rotate between quadrants for generation.
        // Generates stars.
        bool hasCountChanged = true;
        while (hasCountChanged) {
            hasCountChanged = false;

            for (int q = 0; q < quadrants; q++) {
                if (locationsAvailable[q].Count > 0) {
                    hasCountChanged = true;
                    CreateNewStar(q);
                }
            }
        }

        //for (int q = 0; q < quadrants; q++) {
        //    while (locationsAvailable[q].Count > 0) {
        //        // TODO: Multiple star types.
        //        // The star type to instantiate.
        //        GameObject toInstantiate = stars[0];
        //        GameObject instance = Instantiate(toInstantiate, RandomPosition(q), Quaternion.identity) as GameObject;
        //        instance.transform.localScale = new Vector3(4f, 4f, 4f);
        //        instance.transform.SetParent(starmap);
        //    }
        //}
    }

    Vector3 RandomPosition(int quadrant) {
        int randomIndex = Random.Range(0, locationsAvailable[quadrant].Count);
        KeyValuePair<int, int> coords = locationsAvailable[quadrant][randomIndex];
        Vector3 randomPosition = GetRandomPositionFromCoords(coords, quadrant);

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

    Vector3 GetRandomPositionFromCoords(KeyValuePair<int, int> coords, int quadrant) {
        return new Vector3(
            coords.Key + (quadrantLocations[quadrant].Value * rows) + GetRandomDeviation(1),    // x
            coords.Value + (quadrantLocations[quadrant].Key * columns) + GetRandomDeviation(1), // y
            quadrant // z, unused in 2D game, used for debug
        );
    }

    float GetRandomDeviation(int max) {
        return (Random.Range(0, max * 2) - max) * 0.1f;
    }

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

        for (; x < condition; x++) {
            RemoveQuadrantColumns(coords, quadrant, q, qy, x);
        }
    }



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

        for (; y < condition; y++) {
            locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
        }
    }

    void CreateNewStar(int q) {
        GameObject toInstantiate = stars[0];
        GameObject instance = Instantiate(toInstantiate, RandomPosition(q), Quaternion.identity) as GameObject;
        instance.transform.localScale = new Vector3(4f, 4f, 4f);
        instance.transform.SetParent(starmap);
    }

    public void SetupScene() {
        InitializeList();
        StarmapSetup();
    }
}
