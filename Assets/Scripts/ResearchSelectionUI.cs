using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchSelectionUI : MonoBehaviour {

    public Text TitlePanel;
    public Text DescriptionText;

    public GameObject ReserachButton1Obj;
    public GameObject ReserachButton2Obj;
    public GameObject ReserachButton3Obj;
    public GameObject ReserachButton4Obj;

    public Button ResearchButton1;
    public Button ResearchButton2;
    public Button ResearchButton3;
    public Button ResearchButton4;

    public GameObject ResearchPanelObj;

    public List<GameObject> buttonsObj;

    void Start() {
        ResearchPanelObj.SetActive(false);

        ReserachButton1Obj = GameObject.Find("Technology_1_Button");
        ReserachButton2Obj = GameObject.Find("Technology_2_Button");
        ReserachButton3Obj = GameObject.Find("Technology_3_Button");
        ReserachButton4Obj = GameObject.Find("Technology_4_Button");

        ResearchButton1 = ReserachButton1Obj.GetComponent<Button>();
        ResearchButton2 = ReserachButton2Obj.GetComponent<Button>();
        ResearchButton3 = ReserachButton3Obj.GetComponent<Button>();
        ResearchButton4 = ReserachButton4Obj.GetComponent<Button>();

        buttonsObj.Add(ReserachButton1Obj);
        buttonsObj.Add(ReserachButton1Obj);
        buttonsObj.Add(ReserachButton1Obj);
        buttonsObj.Add(ReserachButton1Obj);
    }

    void UpdateText(string Title, string Description, string[] Research) {
        UpdateDimensions(Research.Length);

        TitlePanel.text = Title;
        DescriptionText.text = Description;
    }

    void UpdateDimensions(int number) {

        for(int i = 0; i < number; i++) {
            buttonsObj[i].SetActive(true);
        }
    }
}
