using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameObject uiCanvas;
    public GameObject infoPaneManager;

    public GameObject UICanvasPrefab;
    public GameObject InfoPaneManagerPrefab;
    public void Init() {
        uiCanvas = Instantiate(UICanvasPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
        infoPaneManager = Instantiate(InfoPaneManagerPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, uiCanvas.transform) as GameObject;
        infoPaneManager.GetComponent<InfoPaneManager>().Init();
    }
}
