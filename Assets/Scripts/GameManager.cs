using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public StarGenerator generator;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        generator = GetComponent<StarGenerator>();
        InitGame();
    }

    void InitGame() {
        generator.SetupScene();
    }

    // Update is called once per frame
    void Update() {

    }
}
