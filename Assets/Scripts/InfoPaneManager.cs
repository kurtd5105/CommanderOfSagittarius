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

    public Slider SHPBar;
    public Slider DEFBar;
    public Slider INDBar;
    public Slider ECOBar;
    public Slider RESBar;

    public void Init() {
        ButtonManager.NextTurnDone += TurnDone;
        InitButtons();
    }

    public void InitButtons() {
        ShpLeft = (GameObject.Find("SHP_Arrow_Left")).GetComponent<Button>();
        ShpLeft.onClick.AddListener(() => UpdateSlider("ship", -0.1f, "arrow"));
        ShpRight = (GameObject.Find("SHP_Arrow_Right")).GetComponent<Button>();
        ShpRight.onClick.AddListener(() => UpdateSlider("ship", 0.1f, "arrow"));

        DefLeft = (GameObject.Find("DEF_Arrow_Left")).GetComponent<Button>();
        DefLeft.onClick.AddListener(() => UpdateSlider("defense", -0.1f, "arrow"));
        DefRight = (GameObject.Find("DEF_Arrow_Right")).GetComponent<Button>();
        DefRight.onClick.AddListener(() => UpdateSlider("defense", 0.1f, "arrow"));

        IndLeft = (GameObject.Find("IND_Arrow_Left")).GetComponent<Button>();
        IndLeft.onClick.AddListener(() => UpdateSlider("industry", -0.1f, "arrow"));
        IndRight = (GameObject.Find("IND_Arrow_Right")).GetComponent<Button>();
        IndRight.onClick.AddListener(() => UpdateSlider("industry", 0.1f, "arrow"));

        EcoLeft = (GameObject.Find("ECO_Arrow_Left")).GetComponent<Button>();
        EcoLeft.onClick.AddListener(() => UpdateSlider("ecology", -0.1f, "arrow"));
        EcoRight = (GameObject.Find("ECO_Arrow_Right")).GetComponent<Button>();
        EcoRight.onClick.AddListener(() => UpdateSlider("ecology", 0.1f, "arrow"));

        ResLeft = (GameObject.Find("RES_Arrow_Left")).GetComponent<Button>();
        ResLeft.onClick.AddListener(() => UpdateSlider("research", -0.1f, "arrow"));
        ResRight = (GameObject.Find("RES_Arrow_Right")).GetComponent<Button>();
        ResRight.onClick.AddListener(() => UpdateSlider("research", 0.1f, "arrow"));

        SHPBar = GameObject.Find("SHP_BAR").GetComponent<Slider>();
        SHPBar.onValueChanged.AddListener(delegate { UpdateSlider("ship", SHPBar.value, "slider"); });
        DEFBar = GameObject.Find("DEF_BAR").GetComponent<Slider>();
        DEFBar.onValueChanged.AddListener(delegate { UpdateSlider("defense", DEFBar.value, "slider"); });
        INDBar = GameObject.Find("IND_BAR").GetComponent<Slider>();
        INDBar.onValueChanged.AddListener(delegate { UpdateSlider("industry", INDBar.value, "slider"); });
        ECOBar = GameObject.Find("ECO_BAR").GetComponent<Slider>();
        ECOBar.onValueChanged.AddListener(delegate { UpdateSlider("ecology", ECOBar.value, "slider"); });
        RESBar = GameObject.Find("RES_BAR").GetComponent<Slider>();
        RESBar.onValueChanged.AddListener(delegate { UpdateSlider("research", RESBar.value, "slider"); });
        SHPBar.enabled = false;
        DEFBar.enabled = false;
        INDBar.enabled = false;
        ECOBar.enabled = false;
        RESBar.enabled = false;

    }

    public void OnStarClicked(StarProperties star) {
        currentStar = star;
        UpdatePane();
        SHPBar.enabled = true;
        DEFBar.enabled = true;
        INDBar.enabled = true;
        ECOBar.enabled = true;
        RESBar.enabled = true;
    }

    public void TurnDone() {
        UpdatePane();
    }

    public void UpdateSlider(string name, float value, string element) {
        if (currentStar != null) {
            currentStar.UpdateSpending(name, value, element);
            UpdatePane();
        }
    }

    public void UpdatePane() {
        string maxPop = "MAX POP " + currentStar.effectiveMaxPopulation.ToString("##0");
        string production = currentStar.factories.ToString("###0") + " (RAW " + currentStar.factories.ToString("###0") + ")";

        MaxPop.text = maxPop;
        Population.text = currentStar.population.ToString("##0");
        Bases.text = currentStar.population.ToString("##0");
        Production.text = production;

        SHPBar.value = currentStar.GetSpending("ship");
        DEFBar.value = currentStar.GetSpending("defense");
        INDBar.value = currentStar.GetSpending("industry");
        ECOBar.value = currentStar.GetSpending("ecology");
        RESBar.value = currentStar.GetSpending("research");
    }

    private void OnDestroy() {
        ButtonManager.NextTurnDone -= TurnDone;
    }
}
