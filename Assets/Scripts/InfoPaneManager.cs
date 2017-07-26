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

    public void Init() {
        ButtonManager.NextTurnDone += TurnDone;
    }

    public void OnStarClicked(StarProperties star) {
        currentStar = star;
        UpdatePane();
    }

    public void TurnDone() {
        UpdatePane();
    }

    public void UpdatePane() {
        string maxPop = "MAX POP " + currentStar.effectiveMaxPopulation.ToString("##0");
        string production = currentStar.factories.ToString("###0") + " (RAW " + currentStar.factories.ToString("###0") + ")";

        MaxPop.text = maxPop;
        Population.text = currentStar.population.ToString("##0");
        Bases.text = currentStar.population.ToString("##0");
        Production.text = production;
    }

    private void OnDestroy() {
        ButtonManager.NextTurnDone -= TurnDone;
    }
}
