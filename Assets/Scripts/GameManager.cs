using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public static TechnologyFactory techFactory = null;
    public StarGenerator generator = null;
    public NewGameManager newGame = null;
    public OptionsMenuManager options = null;

    //New game options data
    public List<string> newData;
    public List<string> starData;

    public List<PlayerInfo> playerList;

    int playerCount;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
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

        } else if (scene == SceneManager.GetSceneByName("new_game")) {
            starData = (options.getData()).ToList();
            playerCount = int.Parse(starData[2]) + 1;
        }

        if (scene == SceneManager.GetSceneByName("new_game")) {

        } else if (scene == SceneManager.GetSceneByName("main")) {
            newData = (newGame.getData()).ToList();
            generator = GetComponent<StarGenerator>();
            InitGame();
        }
    }

    void InitGame() {
        techFactory = new TechnologyFactory();

        CreatePlayers();

        //Setup starmap based on player input
        StarScreenManager screenManager = GameObject.Find("StarCollider").GetComponent<StarScreenManager>();

        generator.SetupScene(starData);
        SetupHomeworlds();

        screenManager.maxStarPositions = -generator.maxStarPositions;
        screenManager.minStarPositions = -generator.minStarPositions;
    }

    void CreatePlayers() {
        playerList = new List<PlayerInfo> { new PlayerInfo(Owners.PLAYER, newData[0], newData[1], newData[2], newData[4], newData[3]) };

        for (int i = 1; i < playerCount; i++) {
            //Create rest of AI opponents
            // Todo: randomize the rest of the details such as flag, civ name, etc
            playerList.Add(new PlayerInfo((Owners)(i + 1), newData[0], newData[1], newData[2], newData[4], newData[3]));
        }
    }

    void SetupHomeworlds() {
        for (int i = 0; i < playerCount; i++) {
            playerList[i].AddHomeworld(generator.generatedStars[i].GetComponent<Star>().id, generator.generatedStars[i].GetComponent<Star>());
        }
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= SceneChanged;
    }
}
