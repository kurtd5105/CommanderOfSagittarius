using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public StarGenerator boardScript;

    private int level = 3;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<StarGenerator>();
        InitGame();
    }

    void InitGame() {
        boardScript.SetupScene(level);
    }

    // Update is called once per frame
    void Update() {

    }
}
