using UnityEngine;
using UnityEngine.UI;

public class InfoPaneManager : MonoBehaviour {

    public GameObject infoPane;
    public Star currentStar = null;

    public Text Name;
    public Text MaxPop;
    public Text Population;
    public Text Production;
    public Text Bases;

    public InfoPaneSlider SHPBar;
    public InfoPaneSlider DEFBar;
    public InfoPaneSlider INDBar;
    public InfoPaneSlider ECOBar;
    public InfoPaneSlider RESBar;

    public CanvasGroup SliderGroup;

    public void Init() {
        ButtonManager.NextTurnDone += TurnDone;
        InitButtons();
        UpdatePane();
    }

    public void InitButtons() {
        SHPBar = new InfoPaneSlider("SHP_Arrow_Left", "SHP_Arrow_Right", "SHP_BAR", "ship",     this);
        DEFBar = new InfoPaneSlider("DEF_Arrow_Left", "DEF_Arrow_Right", "DEF_BAR", "defense",  this);
        INDBar = new InfoPaneSlider("IND_Arrow_Left", "IND_Arrow_Right", "IND_BAR", "industry", this);
        ECOBar = new InfoPaneSlider("ECO_Arrow_Left", "ECO_Arrow_Right", "ECO_BAR", "ecology",  this);
        RESBar = new InfoPaneSlider("RES_Arrow_Left", "RES_Arrow_Right", "RES_BAR", "research", this);

        SliderGroup = GameObject.Find("Sliders").GetComponent<CanvasGroup>();
    }

    public void OnStarClicked(Star star) {
        if (IsOnlyStarClicked()) {
            currentStar = star;
            UpdatePane();
        }
    }

    //Gets number of colliders at point clicked.
    bool IsOnlyStarClicked() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Returns component but possibly not in correct order.
            RaycastHit2D[] hits = Physics2D.RaycastAll(cubeRay, Vector2.zero);

            return hits.Length == 1;
        }

        return false;
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
            string name = currentStar.starName;
            string maxPop = "MAX POP " + currentStar.starProperties.effectiveMaxPopulation.ToString("##0");
            string production = currentStar.starProperties.factories.ToString("###0") + " (RAW " + currentStar.starProperties.factories.ToString("###0") + ")";

            Name.text = name;
            MaxPop.text = maxPop;
            Population.text = currentStar.starProperties.population.ToString("##0");
            Bases.text = currentStar.starProperties.population.ToString("##0");
            Production.text = production;

            SHPBar.SetValue(currentStar.GetSpending("ship"    ));
            DEFBar.SetValue(currentStar.GetSpending("defense" ));
            INDBar.SetValue(currentStar.GetSpending("industry"));
            ECOBar.SetValue(currentStar.GetSpending("ecology" ));
            RESBar.SetValue(currentStar.GetSpending("research"));
        }

        UpdateDetailPlate();
        UpdateStatsPlate();
        UpdateSliders();
    }

    private void EnableSliders(bool enable) {
        SHPBar.Enable(enable);
        DEFBar.Enable(enable);
        INDBar.Enable(enable);
        ECOBar.Enable(enable);
        RESBar.Enable(enable);
        SliderGroup.alpha = enable ? 1.0f : 0.0f;
        SliderGroup.blocksRaycasts = enable;
    }

    // Detail plate appears just below the star name.
    private void UpdateDetailPlate() {
        bool enablePlanetInfo = false;

        if (currentStar != null) {
            if (currentStar.starProperties.owner == Owners.PLAYER || currentStar.starProperties.isExplored[Owners.PLAYER]) {
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
        bool showPartialStats = false;
        bool showFullStats = false;

        if (currentStar != null) {
            if (currentStar.starProperties.owner == Owners.PLAYER) {
                showFullStats = true;
            } else if (currentStar.starProperties.isExplored[Owners.PLAYER] && currentStar.starProperties.owner != Owners.NONE) {
                showPartialStats = true;

                /* if (not in radar range) {
                 *     indicate stats not current
                 * }
                 */
            }
        }

        if (showPartialStats) {
            string production = currentStar.starProperties.factories.ToString("###0");
            Production.text = production;
        }

        GameObject.Find("PopulationText")    .GetComponent<Text>().enabled = showFullStats || showPartialStats;
        GameObject.Find("FactoriesText")     .GetComponent<Text>().enabled = showFullStats || showPartialStats;
        GameObject.Find("BaseText")          .GetComponent<Text>().enabled = showFullStats || showPartialStats;
        GameObject.Find("PopulationValue")   .GetComponent<Text>().enabled = showFullStats || showPartialStats;
        GameObject.Find("ProductionValue")   .GetComponent<Text>().enabled = showFullStats || showPartialStats;
        GameObject.Find("BaseValue")         .GetComponent<Text>().enabled = showFullStats || showPartialStats;
        GameObject.Find("Vertical_Divider")  .GetComponent<Image>().enabled = showFullStats || showPartialStats;
        GameObject.Find("Horizontal_Divider").GetComponent<Image>().enabled = showFullStats || showPartialStats;
        GameObject.Find("InfoBorder")        .GetComponent<Image>().enabled = showFullStats || showPartialStats;
    }

    private void UpdateSliders() {
        bool enableSliders = false;
        if (currentStar != null) {
            if (currentStar.starProperties.owner == Owners.PLAYER) {
                enableSliders = true;
            }
        }
        EnableSliders(enableSliders);
    }

    private void OnDestroy() {
        ButtonManager.NextTurnDone -= TurnDone;
    }
}
