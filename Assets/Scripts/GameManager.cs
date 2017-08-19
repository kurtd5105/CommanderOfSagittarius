using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Linq;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public StarGenerator generator = null;
    public NewGameManager newGame = null;
    public OptionsMenuManager options = null;

    //New game options data
    public List<string> newData;
    public List<string> starData;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += SceneChanged;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("new_game")) {

        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("main")) {
            generator = GetComponent<StarGenerator>();
            InitGame();
        }
    }

    void SceneChanged(Scene scene, LoadSceneMode mode) {
        if (mode != LoadSceneMode.Single) {
            return;
        }

        if (scene == SceneManager.GetSceneByName("new_game")) {
            newGame = GameObject.Find("NewGameManager").GetComponent<NewGameManager>();
        }

        if (scene == SceneManager.GetSceneByName("options_menu")) {
            options = GameObject.Find("OptionsManager").GetComponent<OptionsMenuManager>();
        }

        if (scene == SceneManager.GetSceneByName("options_menu")) {
        }

        else if (scene == SceneManager.GetSceneByName("new_game")) {
            starData = (options.getData()).ToList();
        }

        if (scene == SceneManager.GetSceneByName("new_game")) {

        }
        else if (scene == SceneManager.GetSceneByName("main")) {

            newData = (newGame.getData()).ToList();

            generator = GetComponent<StarGenerator>();
            InitGame();
        }
    }

    void InitGame() {
        generator.SetupScene(starData);
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= SceneChanged;
    }
}
