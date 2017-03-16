using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProperties : MonoBehaviour {
    // Current owner specifics.
    public float population;
    public float factories;
    public float waste;
    public float bases;

    // Planet specifics.
    public float maxPopulation;
    public PlanetTypes planetType;
    public List<PlanetModifiers> planetModifiers;
    public Owners owner;

    public void Generate(StarColor color, bool isHomeworld) {
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
        owner = Owners.NONE;
        bases = 0;
        waste = 0;
    }

    // TODO: Add this to a turn event. Unsubscribe if no owner or no planet. Subscribe if otherwise.
    public void Turn() {
        if (planetType != PlanetTypes.NONE && owner != Owners.NONE && population > 0) {
            // 1M Population costs 20 BC, generate 0.5 BC
            // 1 Factory costs 10 BC, generates 1 BC and costs 1 BC of waste
            // Waste costs 0.5 BC to clean up
        }
    }
}
