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

    public float Production      { get; set; } // in BC
    public float WasteProduction { get; set; } // in BC

    public Dictionary<string, float> SpendingBook = new Dictionary<string, float>();

    public static string[] SpendingCategories = new string[5] { "ship", "defense", "industry", "ecology", "research" };

    public void Init() {
        foreach (var category in SpendingCategories) {
            SpendingBook.Add(category, 0.0f);
        }

        Production = ((int)population * 0.5f) + (int)factories;
        WasteProduction = (int)factories;
        // TODO: if the slider isn't locked, round to the nearest unit of 5.

        if ((WasteProduction / 2) > SpendingBook["ecology"] * Production) {
            SpendingBook["ecology"] = ((WasteProduction / 2) / Production);
        }
        SpendingBook["industry"] = 1.0f - SpendingBook["ecology"];
    }

    public void calcSpending(string name, float value) {
        //Prevent value of Spending from going out of 0 <= value <= 1 range.
        float oldValue = SpendingBook[name];
        SpendingBook[name] += value;
        if (SpendingBook[name] > 1.0f) {
            SpendingBook[name] = 1.0f;
        } else if (SpendingBook[name] < 0.0f) {
            SpendingBook[name] = 0.0f;
        }

        BalanceSpending(name, SpendingBook[name] - oldValue);

        //if (SpendingBook[name] > 0.01f && SpendingBook[name] < 1.0f) {
        //    SpendingBook[name] += value;
        //}
        //if ((SpendingBook[name] <= 0.09f && value > 0.0f) || (SpendingBook[name] >= 0.91 && value < 0.0f)) {
        //    SpendingBook[name] += value;
        //}
    }

    private void BalanceSpending(string to, float amount) {
        for (int i = SpendingCategories.Length - 1; i >= 0; i--) {
            if (SpendingCategories[i] == to) {
                continue;
            }

            if (amount > 0) {
                if (SpendingBook[SpendingCategories[i]] >= amount) {
                    SpendingBook[SpendingCategories[i]] -= amount;
                    break;
                } else {
                    amount -= SpendingBook[SpendingCategories[i]];
                    SpendingBook[SpendingCategories[i]] = 0.0f;
                }
            } else {
                if (SpendingBook[SpendingCategories[i]] - amount <= 1.0f) {
                    SpendingBook[SpendingCategories[i]] -= amount;
                    break;
                } else {
                    amount += 1.0f - SpendingBook[SpendingCategories[i]];
                    SpendingBook[SpendingCategories[i]] = 1.0f;
                }
            }
        }
    }

    public void Calculate() {
        float populationSpent = 0.0f;
        float industrySpent = 0.0f;
        // Calculate cleanup of generated waste + existing waste, and spending into population growth.
        if (SpendingBook["ecology"] * Production > WasteProduction / 2) {
            float ecoRemainder = (SpendingBook["ecology"] * Production) - (WasteProduction / 2);

            if (waste / 2 - ecoRemainder < 0) {
                ecoRemainder -= waste / 2;
                waste = 0.0f;
                populationSpent += ecoRemainder;
            } else {
                waste -= SpendingBook["ecology"] * Production * 2;
            }
        } else {
            waste += (WasteProduction / 2) - (SpendingBook["ecology"] * Production);
        }

        // Calculate industry spending.
        industrySpent = SpendingBook["industry"] * Production;

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

        if ((WasteProduction / 2) > SpendingBook["ecology"] * Production) {
            SpendingBook["ecology"] = ((WasteProduction / 2) / Production);
        }

        SpendingBook["industry"] = 1.0f - SpendingBook["ecology"];
    }
}
