using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchSelectionUI : MonoBehaviour {

    public Text TitlePanel;
    public Text DescriptionText;

    public GameObject TitlePanelObj;
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

    public void Init() {

        TitlePanelObj = GameObject.Find("TitlePanel");
        DescriptionTextObj = GameObject.Find("TitleText");
        ResearchPanelObj = GameObject.Find("ResearchUI");
        ResearchButton1Obj = GameObject.Find("Technology_1_Button");
        ResearchButton2Obj = GameObject.Find("Technology_2_Button");
        ResearchButton3Obj = GameObject.Find("Technology_3_Button");
        ResearchButton4Obj = GameObject.Find("Technology_4_Button");
        SelectionPanelObj = GameObject.Find("SelectionPanel");

        TitlePanel = TitlePanelObj.GetComponent<Text>();
        DescriptionText = DescriptionTextObj.GetComponent<Text>();

        ResearchButton1 = ResearchButton1Obj.GetComponent<Button>();
        ResearchButton2 = ResearchButton2Obj.GetComponent<Button>();
        ResearchButton3 = ResearchButton3Obj.GetComponent<Button>();
        ResearchButton4 = ResearchButton4Obj.GetComponent<Button>();

        buttonsObj.Add(ResearchButton1Obj);
        buttonsObj.Add(ResearchButton2Obj);
        buttonsObj.Add(ResearchButton3Obj);
        buttonsObj.Add(ResearchButton4Obj);

        ResearchPanelObj.SetActive(false);
    }

    public void UpdateText(string title, string description, string[] research) {
        //Set what the values are for the Research UI.
        SelectionPanelObj.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

        UpdateDimensions(research.Length);

        TitlePanel.text = title;
        DescriptionText.text = description;

        ResearchPanelObj.SetActive(true);
    }

    public void UpdateDimensions(int number) {
        //Set what buttons are visible and resize of Panel under buttons.
        float height = ResearchButton1.GetComponent<RectTransform>().sizeDelta.y;
        float norm = SelectionPanelObj.GetComponent<RectTransform>().offsetMin.x;
        SelectionPanelObj.GetComponent<RectTransform>().offsetMin = new Vector2(norm, 0);

        resetButtons();

        for (int i = 0; i < number; i++) {
            buttonsObj[i].SetActive(true);
        }

        SelectionPanelObj.GetComponent<RectTransform>().offsetMin += new Vector2(0, height*(4 - number));

        ResearchPanelObj.SetActive(true);
    }

    public void resetButtons() {
        foreach (var button in buttonsObj) {
            button.SetActive(false);
        }
    }
}
