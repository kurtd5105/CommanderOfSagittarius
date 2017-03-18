using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public void NewGameButton(string NewGameLevel) {
        SceneManager.LoadScene(NewGameLevel);
    }

    public void ExitGame() {
        Application.Quit();
    }
}