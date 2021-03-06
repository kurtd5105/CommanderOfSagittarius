﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public delegate void OnNextTurnClicked();
    public static event OnNextTurnClicked NextTurn;
    public delegate void OnNextTurnResearch();
    public static event OnNextTurnResearch NextTurnResearch;
    public delegate void OnNextTurnDone();
    public static event OnNextTurnDone NextTurnDone;
    public delegate void OnMenuClick();
    public static event OnMenuClick MenuClick;

    public void SwitchScene(string newScene) {
        SceneManager.LoadScene(newScene);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void TurnClicked() {
        NextTurn();
        NextTurnResearch();
        NextTurnDone();
    }

    public void ResearchClicked() {
        MenuClick();
    }
}