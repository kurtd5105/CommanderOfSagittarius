using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProperties : MonoBehaviour {
    public float population;
    public float factories;
    public float waste;

    public float maxPopulation;
    public PlanetTypes planetType;
    public List<PlanetModifiers> planetModifiers;

    public void Generate(StarColor color, bool isHomeworld) {
        if (isHomeworld) {
            population = 50;
            factories = 0;
            waste = 0;
            maxPopulation = 100;
            planetType = PlanetTypes.TERRAN;
            planetModifiers.Add(PlanetModifiers.NORMAL);
        } else {
            population = 0;
            factories = 0;
            waste = 0;
            maxPopulation = 0;
            planetType = PlanetTypes.NONE;
            planetModifiers.Add(PlanetModifiers.NORMAL);
        }
    }
}
