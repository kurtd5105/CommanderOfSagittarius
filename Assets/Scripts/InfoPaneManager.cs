using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPaneManager : MonoBehaviour {
    public GameObject starname;
    public GameObject infoPaneText;
    public GameObject infoPane;
    public GameObject infoPanePrefab;
    public NumberDisplayText population;
    public NumberDisplayText factories;

    public void Init() {
        infoPane = Instantiate(infoPanePrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;

        population = new NumberDisplayText();
        factories = new NumberDisplayText();

        // Get the RectTransform in order to position the text.
        RectTransform rt = starname.GetComponent<RectTransform>();
        TextGenerator textGen = new TextGenerator();
        TextGenerationSettings generationSettings = starname.GetComponent<Text>().GetGenerationSettings(rt.rect.size);
        float height = textGen.GetPreferredHeight("Name", generationSettings);
        
        population.text = Instantiate(infoPaneText, new Vector3(70.0f, 0.0f, 0.0f), Quaternion.identity, infoPane.transform) as GameObject;
        factories.text = Instantiate(infoPaneText, new Vector3(70.0f, 0.0f, 0.0f), Quaternion.identity, infoPane.transform) as GameObject;

        // Set correct positioning for the text.
        Vector3 position = rt.anchoredPosition;

        // Move the text down by the planet name's height plus some extra padding.
        position.y -= height + 5.0f;

        // Set the population text's position.
        population.text.GetComponent<RectTransform>().anchoredPosition = position;
        population.text.GetComponent<RectTransform>().anchoredPosition3D = position;

        position.y -= height + 5.0f;

        // Set the factories text's position.
        factories.text.GetComponent<RectTransform>().anchoredPosition = position;
        factories.text.GetComponent<RectTransform>().anchoredPosition3D = position;

        population.Init("Population", 0);
        factories.Init("Factories", 0);
    }
}
