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
        for (int q = 0; q < quadrants; q++) {
            while (locationsAvailable[q].Count > 0) {
                // TODO: Multiple star types.
                // The star type to instantiate.
                GameObject toInstantiate = stars[0];
                GameObject instance = Instantiate(toInstantiate, RandomPosition(q), Quaternion.identity) as GameObject;

                instance.transform.SetParent(starmap);
            }
        }
    }

    Vector3 RandomPosition(int quadrant) {
        int randomIndex = Random.Range(0, locationsAvailable[quadrant].Count);
        KeyValuePair<int, int> coords = locationsAvailable[quadrant][randomIndex];
        Vector3 randomPosition = new Vector3(coords.Key + (quadrantLocations[quadrant].Value * rows) + GetRandomDeviation(1), coords.Value + (quadrantLocations[quadrant].Key * columns) + GetRandomDeviation(1), quadrant);
        // Need to remove coords from other quadrants.
        //coords = new KeyValuePair<int, int>(coords.Value, coords.Key);
        for (int qx = quadrantLocations[quadrant].Key - 1; qx <= quadrantLocations[quadrant].Key + 1; qx++) {
            if (qx < 0) {
                continue;
            }

            for (int qy = quadrantLocations[quadrant].Value - 1; qy <= quadrantLocations[quadrant].Value + 1; qy++) {
                if (qy < 0) {
                    continue;
                }

                int q = -1;
                for (int i = 0; i < quadrants; i++) {
                    if (quadrantLocations[i].Key == qx && quadrantLocations[i].Value == qy) {
                        q = i;
                        break;
                    }
                }

                if (q == -1) {
                    continue;
                }

                if (qx < quadrantLocations[quadrant].Key) {
                    for (int x = rows + (coords.Key - 4); x < rows + (coords.Key + 4); x++) {
                        if (qy < quadrantLocations[quadrant].Value) {
                            for (int y = columns + (coords.Value - 4); y < columns + (coords.Value + 4); y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        } else if (qy == quadrantLocations[quadrant].Value) {
                            for (int y = coords.Value - 4; y < coords.Value + 4; y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        } else {
                            for (int y = (coords.Value - 4) - columns; y < (coords.Value + 4) - columns; y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        }
                    }
                } else if (qx == quadrantLocations[quadrant].Key) {
                    for (int x = coords.Key - 4; x < coords.Key + 4; x++) {
                        if (qy < quadrantLocations[quadrant].Value) {
                            for (int y = columns + (coords.Value - 4); y < columns + (coords.Value + 4); y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        }
                        else if (qy == quadrantLocations[quadrant].Value) {
                            for (int y = coords.Value - 4; y < coords.Value + 4; y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        }
                        else {
                            for (int y = (coords.Value - 4) - columns; y < (coords.Value + 4) - columns; y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        }
                    }
                } else {
                    for (int x = (coords.Key - 4) - rows; x < (coords.Key + 4) - rows; x++) {
                        if (qy < quadrantLocations[quadrant].Value) {
                            for (int y = columns + (coords.Value - 4); y < columns + (coords.Value + 4); y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        }
                        else if (qy == quadrantLocations[quadrant].Value) {
                            for (int y = coords.Value - 4; y < coords.Value + 4; y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        }
                        else {
                            for (int y = (coords.Value - 4) - columns; y < (coords.Value + 4) - columns; y++) {
                                locationsAvailable[q].Remove(new KeyValuePair<int, int>(x, y));
                            }
                        }
                    }
                }

            }
        }

        //for (int x = coords.Key - 4; x < coords.Key + 4; x++) {
        //    for (int y = coords.Value - 4; y < coords.Value + 4; y++) {
        //        locationsAvailable[quadrant].Remove(new KeyValuePair<int, int>(y, x));
        //    }
        //}

        return randomPosition;
    }

    float GetRandomDeviation(int max) {
        return (Random.Range(0, max * 2) - max) * 0.1f;
    }

    public void SetupScene() {
        InitializeList();
        StarmapSetup();
    }
}
