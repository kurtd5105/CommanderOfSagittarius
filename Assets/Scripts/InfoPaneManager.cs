using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPaneManager : MonoBehaviour {
    public GameObject infoPane;
    public GameObject buttonBar;

    public GameObject InfoPanePrefab;
    public GameObject ButtonBarPrefab;

    public void Init() {
        // Create the info pane. Positioning magic...
        infoPane = Instantiate(InfoPanePrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, transform.root) as GameObject;
        RectTransform rt = infoPane.GetComponent<RectTransform>();
        Vector3 position = rt.anchoredPosition3D;

        position.x = -rt.rect.width / 2.0f;
        position.y = 0.0f;
        rt.anchoredPosition = position;
        rt.anchoredPosition3D = position;

        float topOffset = rt.offsetMax.y;
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0.0f);
        rt.offsetMin = new Vector2(rt.offsetMin.x, rt.offsetMin.y - topOffset);

        // Create the button bar.
        buttonBar = Instantiate(ButtonBarPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, transform.root) as GameObject;
        rt = buttonBar.GetComponent<RectTransform>();
        RectTransform prefabRT = ButtonBarPrefab.GetComponent<RectTransform>();

        position = prefabRT.anchoredPosition3D;
        rt.anchoredPosition = position;
        rt.anchoredPosition3D = position;
    }
}
