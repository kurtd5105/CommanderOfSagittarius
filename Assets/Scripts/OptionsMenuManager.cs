using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    public GameObject sizeDropObj;
    public GameObject difficultyDropObj;
    public GameObject oponentsDropObj;

    public Dropdown sizeDrop;
    public Dropdown difficultyDrop;
    public Dropdown oponentsDrop;

    public static int numOponents = 6;

    public void Start()
    {
        sizeDropObj = GameObject.Find("Starmap Size Drop");
        difficultyDropObj = GameObject.Find("Select Difficulty Drop");
        oponentsDropObj = GameObject.Find("Number of Opponents Drop");

        sizeDrop = sizeDropObj.GetComponent<Dropdown>();
        difficultyDrop = difficultyDropObj.GetComponent<Dropdown>();
        oponentsDrop = oponentsDropObj.GetComponent<Dropdown>();

        sizeDrop.ClearOptions();
        difficultyDrop.ClearOptions();
        oponentsDrop.ClearOptions();

        populate();
    }

    public void populate()
    {
        foreach (string diff in Enum.GetNames(typeof(Difficulty))) {
            difficultyDrop.options.Add(new Dropdown.OptionData(diff));
        }

        foreach (string size in Enum.GetNames(typeof(Sizes))) {
            sizeDrop.options.Add(new Dropdown.OptionData(size));
        }

        for (int i = 1; i <= numOponents; i++) {
            oponentsDrop.options.Add(new Dropdown.OptionData((i + "")));
        }

        difficultyDrop.RefreshShownValue();
        sizeDrop.RefreshShownValue();
        oponentsDrop.RefreshShownValue();
    }

    public List<string> getData() {
        var data = new List<string>();

        data.Add(difficultyDrop.options[difficultyDrop.value].text);
        data.Add(sizeDrop.options[sizeDrop.value].text);
        data.Add(oponentsDrop.options[oponentsDrop.value].text);

        return data;
    }
}
