using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    public string starName;
    public StarProperties starProperties;
    StarSpending spendingInfo;
    // Corresponds to location in master star array.
    public uint id;

    private InfoPaneManager InfoPane;

    public void InitAndGenerate(InfoPaneManager infoPane, StarColor color, bool isHomeworld, uint id, Owners owner = Owners.NONE) {
        starProperties = new StarProperties();
        starProperties.InitAndGenerate(color, isHomeworld, owner);
        spendingInfo = new StarSpending();

        // Init spending info.
        spendingInfo.population             = starProperties.population;
        spendingInfo.factories              = starProperties.factories;
        spendingInfo.waste                  = starProperties.waste;
        spendingInfo.reserves               = starProperties.reserves;
        spendingInfo.maxPopulation          = starProperties.maxPopulation;
        spendingInfo.effectiveMaxPopulation = starProperties.effectiveMaxPopulation;
        spendingInfo.reserves               = starProperties.reserves;
        spendingInfo.Init();

        ButtonManager.NextTurn += Turn;

        InfoPane = infoPane;
    }

    public void UpdateSpending(string name, float value, string element) {
        if (element == "slider") {
            value -= spendingInfo.SpendingBook[name];
        }
        spendingInfo.calcSpending(name, value);
    }

    public float GetSpending(string name) {
        return spendingInfo.SpendingBook[name];
    }

    // TODO: Add this to a turn event. Unsubscribe if no owner or no planet. Subscribe if otherwise.
    public void Turn() {
        if (starProperties.planetType != PlanetTypes.NONE && starProperties.owner != Owners.NONE && starProperties.population > 0) {
            // 1M Population costs 20 BC, generate 0.5 BC
            // 1 Factory costs 10 BC, generates 1 BC and costs 1 BC of waste
            // Waste costs 0.5 BC to clean up
            spendingInfo.Calculate();

            // Temporary, for debug purposes.
            starProperties.population = spendingInfo.population;
            starProperties.factories = spendingInfo.factories;
            starProperties.waste = spendingInfo.waste;
            starProperties.reserves = spendingInfo.reserves;
            starProperties.maxPopulation = spendingInfo.maxPopulation;
            starProperties.effectiveMaxPopulation = spendingInfo.effectiveMaxPopulation;
        }
    }

    private void OnDestroy() {
        ButtonManager.NextTurn -= Turn;
    }

    private void OnMouseDown() {
        InfoPane.OnStarClicked(this);
    }
}
