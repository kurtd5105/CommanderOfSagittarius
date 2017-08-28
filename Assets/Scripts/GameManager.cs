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

    public List<PlayerInfo> playerList;

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

            CreatePlayers();

            generator = GetComponent<StarGenerator>();
            InitGame();
        }
    }

    void InitGame() {
        //Setup starmap based on player input
        StarScreenManager screenManager = GameObject.Find("StarCollider").GetComponent<StarScreenManager>();
        generator.SetupScene(starData);
        screenManager.maxStarPositions = -generator.maxStarPositions;
        screenManager.minStarPositions = -generator.minStarPositions;
    }

    void CreatePlayers() {
        playerList = new List<PlayerInfo>();

        for (int i = 0; i <= int.Parse(starData[2]); i++)
        {
            PlayerInfo player = new PlayerInfo();

            if (i == 0)
            {
                //Create human player
                player.Init(Owners.PLAYER, newData[0], newData[1], newData[2], newData[4], newData[3]);
            }
            else
            {
                //Create rest of AI opponents
                player.Init((Owners)(i + 1), newData[0], newData[1], newData[2], newData[4], newData[3]);
            }

            playerList.Add(player);
        }
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= SceneChanged;
    }
}
