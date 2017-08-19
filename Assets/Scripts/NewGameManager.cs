using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameManager : MonoBehaviour {

    public GameObject raceDropObj;
    public GameObject flagDropObj;
    public GameObject civInputObj;
    public GameObject leaderInputObj;
    public GameObject homeInputObj;
    public GameObject colorPickerObj;

    public Dropdown raceDrop;
    public Dropdown flagDrop;

    public InputField civInput;
    public InputField leaderInput;
    public InputField homeInput;

    public CUIColorPicker colorPicker;

    public Sprite[] flags;

    public void Start() {

        raceDropObj = GameObject.Find("Select Race Drop");
        flagDropObj = GameObject.Find("Flag Drop");
        civInputObj = GameObject.Find("Civilization Input");
        leaderInputObj = GameObject.Find("Leader Input");
        homeInputObj = GameObject.Find("Homeworld Input");
        colorPickerObj = GameObject.Find("CUIColorPicker");

        raceDrop = raceDropObj.GetComponent<Dropdown>();
        flagDrop = flagDropObj.GetComponent<Dropdown>();
        civInput = civInputObj.GetComponent<InputField>();
        leaderInput = leaderInputObj.GetComponent<InputField>();
        homeInput = homeInputObj.GetComponent<InputField>();
        colorPicker = colorPickerObj.GetComponent<CUIColorPicker>();

        raceDrop.ClearOptions();
        flagDrop.ClearOptions();

        populate();
    }

    //Populate the Dropdowns with data.
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

    //Return new game data to Game Manager.
    public List<string> getData() {
        var data = new List<string>();

        data.Add(raceDrop.options[raceDrop.value].text);
        data.Add((flagDrop.options[flagDrop.value]).image.name);
        data.Add(civInput.text);
        data.Add(leaderInput.text);
        data.Add(homeInput.text);
        data.Add((colorPicker.Color).ToString());

        return data;
    }
}