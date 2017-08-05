using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPaneManager : MonoBehaviour {

    public GameObject infoPane;
    public StarProperties currentStar = null;

    public Text Name;
    public Text MaxPop;
    public Text Population;
    public Text Production;
    public Text Bases;

    public Button ShpLeft;
    public Button DefLeft;
    public Button IndLeft;
    public Button EcoLeft;
    public Button ResLeft;

    public Button ShpRight;
    public Button DefRight;
    public Button IndRight;
    public Button EcoRight;
    public Button ResRight;

    public Slider SHPBar;
    public Slider DEFBar;
    public Slider INDBar;
    public Slider ECOBar;
    public Slider RESBar;

    bool DetailPlateVisible;
    bool StatsPlateVisible;

    public void Init() {
        ButtonManager.NextTurnDone += TurnDone;
        InitButtons();
        UpdatePane();
    }

    public void InitButtons() {
        ShpLeft = (GameObject.Find("SHP_Arrow_Left")).GetComponent<Button>();
        DefLeft = (GameObject.Find("DEF_Arrow_Left")).GetComponent<Button>();
        IndLeft = (GameObject.Find("IND_Arrow_Left")).GetComponent<Button>();
        EcoLeft = (GameObject.Find("ECO_Arrow_Left")).GetComponent<Button>();
        ResLeft = (GameObject.Find("RES_Arrow_Left")).GetComponent<Button>();

        ShpRight = (GameObject.Find("SHP_Arrow_Right")).GetComponent<Button>();
        DefRight = (GameObject.Find("DEF_Arrow_Right")).GetComponent<Button>();
        IndRight = (GameObject.Find("IND_Arrow_Right")).GetComponent<Button>();
        EcoRight = (GameObject.Find("ECO_Arrow_Right")).GetComponent<Button>();
        ResRight = (GameObject.Find("RES_Arrow_Right")).GetComponent<Button>();

        ShpLeft.onClick.AddListener(() => UpdateSlider("ship",     -0.1f, "arrow"));
        DefLeft.onClick.AddListener(() => UpdateSlider("defense",  -0.1f, "arrow"));
        IndLeft.onClick.AddListener(() => UpdateSlider("industry", -0.1f, "arrow"));
        EcoLeft.onClick.AddListener(() => UpdateSlider("ecology",  -0.1f, "arrow"));
        ResLeft.onClick.AddListener(() => UpdateSlider("research", -0.1f, "arrow"));

        ShpRight.onClick.AddListener(() => UpdateSlider("ship",     0.1f, "arrow"));
        DefRight.onClick.AddListener(() => UpdateSlider("defense",  0.1f, "arrow"));
        IndRight.onClick.AddListener(() => UpdateSlider("industry", 0.1f, "arrow"));
        EcoRight.onClick.AddListener(() => UpdateSlider("ecology",  0.1f, "arrow"));
        ResRight.onClick.AddListener(() => UpdateSlider("research", 0.1f, "arrow"));

        SHPBar = GameObject.Find("SHP_BAR").GetComponent<Slider>();
        DEFBar = GameObject.Find("DEF_BAR").GetComponent<Slider>();
        INDBar = GameObject.Find("IND_BAR").GetComponent<Slider>();
        ECOBar = GameObject.Find("ECO_BAR").GetComponent<Slider>();
        RESBar = GameObject.Find("RES_BAR").GetComponent<Slider>();

        SHPBar.onValueChanged.AddListener(delegate { UpdateSlider("ship",     SHPBar.value, "slider"); });
        DEFBar.onValueChanged.AddListener(delegate { UpdateSlider("defense",  DEFBar.value, "slider"); });
        INDBar.onValueChanged.AddListener(delegate { UpdateSlider("industry", INDBar.value, "slider"); });
        ECOBar.onValueChanged.AddListener(delegate { UpdateSlider("ecology",  ECOBar.value, "slider"); });
        RESBar.onValueChanged.AddListener(delegate { UpdateSlider("research", RESBar.value, "slider"); });

        EnableSliders(false);
    }

    public void OnStarClicked(StarProperties star) {
        currentStar = star;
        UpdatePane();
        EnableSliders(true);
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
        if (currentStar != null) {
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

        UpdateDetailPlate();
        UpdateStatsPlate();
    }

    private void EnableSliders(bool enable) {
        SHPBar.enabled = enable;
        DEFBar.enabled = enable;
        INDBar.enabled = enable;
        ECOBar.enabled = enable;
        RESBar.enabled = enable;
    }

    // Detail plate appears just below the star name.
    private void UpdateDetailPlate() {
        bool enablePlanetInfo = false;

        if (currentStar != null) {
            if (currentStar.owner == Owners.PLAYER || currentStar.isExplored[Owners.PLAYER]) {
                enablePlanetInfo = true;
            }
        }

        // Hide or show detail plate based on if details should be shown or not.
        GameObject.Find("PlanetTypeText").GetComponent<Text>().enabled = enablePlanetInfo;
        GameObject.Find("MaxPopText").GetComponent<Text>().enabled = enablePlanetInfo;
        GameObject.Find("UnexploredText").GetComponent<Text>().enabled = !enablePlanetInfo;
    }

    // Stats plate appears below the detail plate, if at all.
    private void UpdateStatsPlate() {
        
    }

    private void OnDestroy() {
        ButtonManager.NextTurnDone -= TurnDone;
    }
}
