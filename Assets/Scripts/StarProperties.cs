using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProperties : MonoBehaviour {
    // Current owner specifics, temporary for debug info.
    public float population;
    public float factories;
    public float waste;
    public float bases;
    public float reserves;
    // Current owner specifics.
    StarSpending spendingInfo;

    // Planet specifics.
    public float maxPopulation;
    public float effectiveMaxPopulation;
    public PlanetTypes planetType;
    public List<PlanetModifiers> planetModifiers;
    public Owners owner;

    public void InitAndGenerate(StarColor color, bool isHomeworld, Owners owner = Owners.NONE) {
        spendingInfo = new StarSpending();

        // Generate a new planet based on the star color and if it's a homeworld or not.
        if (isHomeworld) {
            // TODO: These need to vary based on race and difficulty
            population = 50;
            factories = 30;
            maxPopulation = 100;
            planetType = PlanetTypes.TERRAN;
            planetModifiers.Add(PlanetModifiers.NORMAL);
        } else {
            population = 0;
            factories = 0;
            maxPopulation = 0;
            planetType = PlanetTypes.NONE;
            planetModifiers.Add(PlanetModifiers.NORMAL);
        }
        this.owner = owner;
        bases = 0;
        waste = 0;
        reserves = 0;
        effectiveMaxPopulation = maxPopulation;

        // Init spending info.
        spendingInfo.population = population;
        spendingInfo.factories = factories;
        spendingInfo.waste = waste;
        spendingInfo.reserves = reserves;
        spendingInfo.maxPopulation = maxPopulation;
        spendingInfo.effectiveMaxPopulation = effectiveMaxPopulation;
        spendingInfo.reserves = reserves;
        spendingInfo.Init();

        ButtonManager.NextTurn += Turn;
}

    // TODO: Add this to a turn event. Unsubscribe if no owner or no planet. Subscribe if otherwise.
    public void Turn() {
        if (planetType != PlanetTypes.NONE && owner != Owners.NONE && population > 0) {
            // 1M Population costs 20 BC, generate 0.5 BC
            // 1 Factory costs 10 BC, generates 1 BC and costs 1 BC of waste
            // Waste costs 0.5 BC to clean up
            spendingInfo.Calculate();

            // Temporary, for debug purposes.
            population = spendingInfo.population;
            factories = spendingInfo.factories;
            waste = spendingInfo.waste;
            reserves = spendingInfo.reserves;
            maxPopulation = spendingInfo.maxPopulation;
            effectiveMaxPopulation = spendingInfo.effectiveMaxPopulation;
        }
    }

    private void OnDestroy() {
        ButtonManager.NextTurn -= Turn;
    }
}
