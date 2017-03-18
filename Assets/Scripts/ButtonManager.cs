using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public void SwitchScene(string newScene) {
        SceneManager.LoadScene(newScene);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void SetupButtons(string name) {
        if (name == "main") {
            //Instantiate();
        }
    }
}