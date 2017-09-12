using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchSelectionUI : MonoBehaviour {

    public Text TitlePanel;
    public Text DescriptionText;

    public GameObject ResearchPanelObj;

    void Start() {
        ResearchPanelObj.SetActive(true);
    }

    void UpdateText(string Title, string Description) {
        TitlePanel.text = Title;
        DescriptionText.text = Description;
    }
}
