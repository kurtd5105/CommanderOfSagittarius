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

    void InitializeList() {
        locationsAvailable = new List<KeyValuePair<int, int>>[quadrants];

        // Need to rotate between quadrants for generation.

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
        int spawned = 0;
        starmap = new GameObject("Starmap").transform;

        for (int q = 0; q < quadrants; q++) {
            while (locationsAvailable[q].Count > 0) {
                GameObject toInstantiate = stars[0];

                GameObject instance = Instantiate(toInstantiate, RandomPosition(q), Quaternion.identity) as GameObject;

                instance.transform.SetParent(starmap);
                spawned++;
            }
        }
    }

    Vector3 RandomPosition(int quadrant) {
        int randomIndex = Random.Range(0, locationsAvailable[quadrant].Count);
        KeyValuePair<int, int> coords = locationsAvailable[quadrant][randomIndex];
        Vector3 randomPosition = new Vector3(coords.Key, coords.Value, 0f);

        // Need to remove coords from other quadrants.

        for (int x = coords.Key - 3; x < coords.Key + 3; x++) {
            for (int y = coords.Value - 3; y < coords.Value + 3; y++) {
                locationsAvailable[quadrant].Remove(new KeyValuePair<int, int>(x, y));
            }
        }

        return randomPosition;
    }

    public void SetupScene() {
        InitializeList();
        StarmapSetup();
    }
}
