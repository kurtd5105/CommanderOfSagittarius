using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomWeight<T> : MonoBehaviour {
    //Data for weighted random.
    private int totalWeight;
    private int r = 0;
    private List<KeyValuePair<T, int>> weights;

    public RandomWeight() {
        totalWeight = 0;
        r = 0;
        weights = new List<KeyValuePair<T, int>>();
    }

    public void AddWeight(T key, int weight) {
        weights.Add(new KeyValuePair<T, int>(key, weight));
        totalWeight += weight;
    }

    public T GetRandomKey() {
        r = Random.Range(1, totalWeight);

        foreach (var element in weights) {
            if (r < element.Value) {
                Debug.Log(element.Key);
                return element.Key;
            }
            r -= element.Value;
        }

        // Should never reach, return the first key.
        Debug.Assert(false);
        return weights[0].Key;
    }
}
