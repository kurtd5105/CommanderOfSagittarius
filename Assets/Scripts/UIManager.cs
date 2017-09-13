using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameObject UICanvas;
    public GameObject InfoPaneManager;
    public GameObject ButtonBarManager;
    public GameObject ResearchSelectionUI;

    void Awake() {
        InfoPaneManager.GetComponent<InfoPaneManager>().Init();
        ButtonBarManager.GetComponent<ButtonBarManager>().Init();
        ResearchSelectionUI.GetComponent<ResearchSelectionUI>().Init();
    }
}
