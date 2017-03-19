using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1M Population costs 20 BC, generate 0.5 BC
// 1 Factory costs 10 BC, generates 1 BC and costs 1 BC of waste
// Waste costs 0.5 BC to clean up
public class StarSpending {
    public float population;
    public float waste;
    public float factories;
    public float reserves;
    public float maxPopulation;
    public float effectiveMaxPopulation;

    // Spending parameter to be set by the planet spending sliders.
    public float ShipSpending     { get; set; } // in % of production
    public float BaseSpending     { get; set; } // in % of production
    public float IndustrySpending { get; set; } // in % of production
    public float EcoSpending      { get; set; } // in % of production
    public float ResearchSpending { get; set; } // in % of production


    public float Production      { get; set; } // in BC
    public float WasteProduction { get; set; } // in BC

    public void Init() {
        ShipSpending     = 0.0f;
        BaseSpending     = 0.0f;
        IndustrySpending = 0.0f;
        EcoSpending      = 0.0f;
        ResearchSpending = 0.0f;
        Production = ((int)population * 0.5f) + (int)factories;
        WasteProduction = (int)factories;
        // TODO: if the slider isn't locked, round to the nearest unit of 5.

        if ((WasteProduction / 2) > EcoSpending * Production) {
            EcoSpending = ((WasteProduction / 2) / Production);
        }
        IndustrySpending = 1.0f - EcoSpending;
    }

    public void Calculate() {
        float populationSpent = 0.0f;
        float industrySpent = 0.0f;
        // Calculate cleanup of generated waste + existing waste, and spending into population growth.
        if (EcoSpending * Production > WasteProduction / 2) {
            float ecoRemainder = (EcoSpending * Production) - (WasteProduction / 2);

            if (waste / 2 - ecoRemainder < 0) {
                ecoRemainder -= waste / 2;
                waste = 0.0f;
                populationSpent += ecoRemainder;
            } else {
                waste -= EcoSpending * Production * 2;
            }
        } else {
            waste += (WasteProduction / 2) - (EcoSpending * Production);
        }

        // Calculate industry spending.
        industrySpent = IndustrySpending * Production;

        // Natural population growth. Starts out low, peaks at half, ends low.
        population += (float)((-Math.Pow(20 * ((maxPopulation / 2.0f) - population) / maxPopulation, 2) + 100.0f) / 1000.0f + 0.01f) * population;
        population += populationSpent / 20.0f;
        factories += industrySpent / 10.0f;

        // TODO: Calculate effective max population based on waste.

        if (population > effectiveMaxPopulation) {
            reserves += (population - effectiveMaxPopulation) * 20.0f;
            population = effectiveMaxPopulation;
        }
        if (factories > population) {
            reserves += (factories - population) * 10.0f;
            factories = population;
        }

        Production = ((int)population * 0.5f) + (int)factories;
        WasteProduction = (int)factories;
        // TODO: if the slider isn't locked, round to the nearest unit of 5.

        if ((WasteProduction / 2) > EcoSpending * Production) {
            EcoSpending = ((WasteProduction / 2) / Production);
        }

        IndustrySpending = 1.0f - EcoSpending;
    }
}
