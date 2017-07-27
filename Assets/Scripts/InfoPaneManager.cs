using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPaneManager : MonoBehaviour {

    public GameObject infoPane;
    public StarProperties currentStar;

    public Text Name;
    public Text MaxPop;
    public Text Population;
    public Text Production;
    public Text Bases;

    public Button ShpLeft;
    public Button ShpRight;
    public Button DefLeft;
    public Button DefRight;
    public Button IndLeft;
    public Button IndRight;
    public Button EcoLeft;
    public Button EcoRight;
    public Button ResLeft;
    public Button ResRight;

    public Image SHPBar;
    public Image DEFBar;
    public Image INDBar;
    public Image ECOBar;
    public Image RESBar;

    public void Init() {
        ButtonManager.NextTurnDone += TurnDone;
        InitButtons();
    }

    public void InitButtons() {
        ShpLeft = (GameObject.Find("SHP_Arrow_Left")).GetComponent<Button>();
        ShpLeft.onClick.AddListener(() => UpdateSlider("Shp", -0.1f));
        ShpRight = (GameObject.Find("SHP_Arrow_Right")).GetComponent<Button>();
        ShpRight.onClick.AddListener(() => UpdateSlider("Shp", 0.1f));

        DefLeft = (GameObject.Find("DEF_Arrow_Left")).GetComponent<Button>();
        DefLeft.onClick.AddListener(() => UpdateSlider("Def", -0.1f));
        DefRight = (GameObject.Find("DEF_Arrow_Right")).GetComponent<Button>();
        DefRight.onClick.AddListener(() => UpdateSlider("Def", 0.1f));

        IndLeft = (GameObject.Find("IND_Arrow_Left")).GetComponent<Button>();
        IndLeft.onClick.AddListener(() => UpdateSlider("Ind", -0.1f));
        IndRight = (GameObject.Find("IND_Arrow_Right")).GetComponent<Button>();
        IndRight.onClick.AddListener(() => UpdateSlider("Ind", 0.1f));

        EcoLeft = (GameObject.Find("ECO_Arrow_Left")).GetComponent<Button>();
        EcoLeft.onClick.AddListener(() => UpdateSlider("Eco", -0.1f));
        EcoRight = (GameObject.Find("ECO_Arrow_Right")).GetComponent<Button>();
        EcoRight.onClick.AddListener(() => UpdateSlider("Eco", 0.1f));

        ResLeft = (GameObject.Find("RES_Arrow_Left")).GetComponent<Button>();
        ResLeft.onClick.AddListener(() => UpdateSlider("Res", -0.1f));
        ResRight = (GameObject.Find("RES_Arrow_Right")).GetComponent<Button>();
        ResRight.onClick.AddListener(() => UpdateSlider("Res", 0.1f));

        SHPBar = (GameObject.Find("SHP_Bar")).GetComponent<Image>();
        DEFBar = (GameObject.Find("DEF_Bar")).GetComponent<Image>();
        INDBar = (GameObject.Find("IND_Bar")).GetComponent<Image>();
        ECOBar = (GameObject.Find("ECO_Bar")).GetComponent<Image>();
        RESBar = (GameObject.Find("RES_Bar")).GetComponent<Image>();
    }

    public void OnStarClicked(StarProperties star) {
        currentStar = star;
        UpdatePane();
    }

    public void TurnDone() {
        UpdatePane();
    }

    public void UpdateSlider(string name, float value) {
        currentStar.UpdateSlider(name, value);
        UpdatePane();
    }

    public void UpdatePane() {
        string maxPop = "MAX POP " + currentStar.effectiveMaxPopulation.ToString("##0");
        string production = currentStar.factories.ToString("###0") + " (RAW " + currentStar.factories.ToString("###0") + ")";

        MaxPop.text = maxPop;
        Population.text = currentStar.population.ToString("##0");
        Bases.text = currentStar.population.ToString("##0");
        Production.text = production;

        SHPBar.fillAmount = currentStar.slideVal["Shp"];
        DEFBar.fillAmount = currentStar.slideVal["Def"];
        INDBar.fillAmount = currentStar.slideVal["Ind"];
        ECOBar.fillAmount = currentStar.slideVal["Eco"];
        RESBar.fillAmount = currentStar.slideVal["Res"];
    }

    private void OnDestroy() {
        ButtonManager.NextTurnDone -= TurnDone;
    }
}
