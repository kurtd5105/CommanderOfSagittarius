using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchSelectionUI : MonoBehaviour {

    public Text TitleText;
    public Text DescriptionText;

    public GameObject TitleTextObj;
    public GameObject DescriptionTextObj;
    public GameObject ResearchButton1Obj;
    public GameObject ResearchButton2Obj;
    public GameObject ResearchButton3Obj;
    public GameObject ResearchButton4Obj;
    public GameObject ResearchPanelObj;
    public GameObject SelectionPanelObj;

    public Button ResearchButton1;
    public Button ResearchButton2;
    public Button ResearchButton3;
    public Button ResearchButton4;

    public List<GameObject> buttonsObj;

    public Vector2 normResearchUI;
    public Vector2 normSelectionPanel;

    public void Init() {

        TitleTextObj = GameObject.Find("TitleText");
        DescriptionTextObj = GameObject.Find("DescriptionText");
        ResearchPanelObj = GameObject.Find("ResearchUI");
        ResearchButton1Obj = GameObject.Find("Technology_1_Button");
        ResearchButton2Obj = GameObject.Find("Technology_2_Button");
        ResearchButton3Obj = GameObject.Find("Technology_3_Button");
        ResearchButton4Obj = GameObject.Find("Technology_4_Button");
        SelectionPanelObj = GameObject.Find("SelectionPanel");

        TitleText = TitleTextObj.GetComponent<Text>();
        DescriptionText = DescriptionTextObj.GetComponent<Text>();

        ResearchButton1 = ResearchButton1Obj.GetComponent<Button>();
        ResearchButton2 = ResearchButton2Obj.GetComponent<Button>();
        ResearchButton3 = ResearchButton3Obj.GetComponent<Button>();
        ResearchButton4 = ResearchButton4Obj.GetComponent<Button>();

        buttonsObj.Add(ResearchButton1Obj);
        buttonsObj.Add(ResearchButton2Obj);
        buttonsObj.Add(ResearchButton3Obj);
        buttonsObj.Add(ResearchButton4Obj);

        //Save initial right and bottom dimensions of UI.
        normResearchUI = ResearchPanelObj.GetComponent<RectTransform>().offsetMin;
        normSelectionPanel = SelectionPanelObj.GetComponent<RectTransform>().offsetMin;

        ResearchPanelObj.SetActive(false);

        //UpdateDimensions(1);
    }

    public void UpdateText(string title, string description, string[] research) {
        UpdateDimensions(research.Length);

        TitleText.text = title;
        DescriptionText.text = description;

        ResearchPanelObj.SetActive(true);
    }

    public void UpdateDimensions(int number) {
        //Set what buttons are visible and resize of Panel under buttons.
        float height = ResearchButton1.GetComponent<RectTransform>().sizeDelta.y;

        resetButtons();

        for (int i = 0; i < number; i++) {
            buttonsObj[i].SetActive(true);
        }

        SelectionPanelObj.GetComponent<RectTransform>().offsetMin += new Vector2(0, height*(4 - number));
        ResearchPanelObj.GetComponent<RectTransform>().offsetMin += new Vector2(0, height * (4 - number));

        ResearchPanelObj.SetActive(true);
    }

    public void resetButtons() {
        foreach (var button in buttonsObj) {
            button.SetActive(false);
        }
    }

    public void onClick(int item) {

        //TODO: Handle player click.

        //Reset the UI size and buttons.
        ResearchPanelObj.GetComponent<RectTransform>().offsetMin = normResearchUI;
        SelectionPanelObj.GetComponent<RectTransform>().offsetMin = normSelectionPanel;

        ResearchPanelObj.SetActive(false);
        resetButtons();
    }
}
