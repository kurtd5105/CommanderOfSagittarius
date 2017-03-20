using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public static GameObject buttonManager = null;
    public GameObject infoPaneManager = null;

    public StarGenerator generator = null;
    public GameObject ButtonManagerPrefab = null;
    public GameObject InfoPaneManagerPrefab = null;

    private Transform managers;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += SceneChanged;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("main_menu")) {
            if (managers == null) {
                managers = new GameObject("Managers").transform;
                buttonManager = Instantiate(ButtonManagerPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
                buttonManager.transform.SetParent(managers);
                DontDestroyOnLoad(managers);
            }
        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("main")) {
            generator = GetComponent<StarGenerator>();
            InitGame();
            infoPaneManager = Instantiate(InfoPaneManagerPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
            infoPaneManager.GetComponent<InfoPaneManager>().Init();
        }
    }

    void SceneChanged(Scene scene, LoadSceneMode mode) {
        if (mode != LoadSceneMode.Single) {
            return;
        }

        if (scene == SceneManager.GetSceneByName("main_menu")) {
            if (managers == null) {
                managers = new GameObject("Managers").transform;
                buttonManager = Instantiate(ButtonManagerPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
                buttonManager.transform.SetParent(managers);
                DontDestroyOnLoad(managers);
            }
        }
        else if (scene == SceneManager.GetSceneByName("main")) {
            generator = GetComponent<StarGenerator>();
            InitGame();
            infoPaneManager = Instantiate(InfoPaneManagerPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
            infoPaneManager.GetComponent<InfoPaneManager>().Init();
        }

    }

    void InitGame() {
        generator.SetupScene();
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= SceneChanged;
    }
}
