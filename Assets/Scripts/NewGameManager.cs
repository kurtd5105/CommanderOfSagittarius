using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameManager : MonoBehaviour {

    public GameObject raceDropObj;
    public GameObject flagDropObj;

    public Dropdown raceDrop;
    public Dropdown flagDrop;

    public InputField civInput;
    public InputField raceInput;
    public InputField homeInput;

    public Sprite[] flags;

    public void Start() {

        raceDropObj = GameObject.Find("Select Race Drop");
        flagDropObj = GameObject.Find("Flag Drop");

        raceDrop = raceDropObj.GetComponent<Dropdown>();
        flagDrop = flagDropObj.GetComponent<Dropdown>();

        raceDrop.ClearOptions();
        flagDrop.ClearOptions();

        populate();
    }

    public void populate() {
        flags = Resources.LoadAll<Sprite>("Flags");

        foreach (string race in Enum.GetNames(typeof(Races))) {
            raceDrop.options.Add(new Dropdown.OptionData(race));
        }

        foreach(Sprite flag in flags) {
            flagDrop.options.Add(new Dropdown.OptionData(flag));
        }

        raceDrop.RefreshShownValue();
        flagDrop.RefreshShownValue();
    }
}