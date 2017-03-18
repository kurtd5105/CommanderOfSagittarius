﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public delegate void OnNextTurnClicked();
    public static event OnNextTurnClicked NextTurn;
    public void SwitchScene(string newScene) {
        SceneManager.LoadScene(newScene);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void TurnClicked() {
        NextTurn();
    }
}