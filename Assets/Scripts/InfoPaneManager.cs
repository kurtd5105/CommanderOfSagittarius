using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPaneManager : MonoBehaviour {
    public GameObject starname;
    public GameObject infoPaneText;
    public GameObject infoPane;
    public GameObject infoPanePrefab;
    public NumberDisplayText population;
    public NumberDisplayText factories;

    public void Init() {
        infoPane = Instantiate(infoPanePrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;

        Vector3 position = starname.GetComponent<RectTransform>().position;
        RectTransform rt = starname.GetComponent<RectTransform>();

        position.y -= rt.rect.height + 5.0f;

        population = new NumberDisplayText();

        population.text = Instantiate(infoPaneText, position, Quaternion.identity) as GameObject;
        population.text.transform.SetParent(infoPane.transform);
        population.text.transform.SetAsLastSibling();

        population.Init("Population", 0);
    }
}
