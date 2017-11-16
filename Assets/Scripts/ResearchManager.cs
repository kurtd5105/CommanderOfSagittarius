using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The research manager handles all the research calculations and tracking for research and owned tech.
public class ResearchManager {
    // Percentage allocation to research spending, from 0.0f - 1.0f, the sum of all values = 1.0f.
    public Dictionary<string, float> researchSpendingBook;
    // RPs that have been allocated in each research location so far.
    public Dictionary<string, float> researchProgress;
    // The tech that each field is currently researching.
    public Dictionary<string, Technology> techSelection;
    // The tech that's currently owned by the player.
    public Dictionary<string, List<Technology>> possessedTech;

    // TODO: Add method of tracking researched tech, and initialize it with base tech.
    private TechnologyFactory factory;

    public ResearchManager(TechnologyFactory factory) {
        // TODO: make this able to be retrieved with a getter.
        this.factory = factory;
        // TODO: Set up each field and research for level 1 tech.
        researchSpendingBook = new Dictionary<string, float>();
        researchProgress = new Dictionary<string, float>();
        techSelection = new Dictionary<string, Technology>();
        possessedTech = new Dictionary<string, List<Technology>>();

        researchSpendingBook["electronics"] = 0.16f;
        researchSpendingBook["energy"     ] = 0.16f;
        researchSpendingBook["engines"    ] = 0.16f;
        researchSpendingBook["weapons"    ] = 0.16f;
        researchSpendingBook["biology"    ] = 0.18f;
        researchSpendingBook["chemistry"  ] = 0.18f;

        researchProgress["electronics"] = 0.0f;
        researchProgress["energy"     ] = 0.0f;
        researchProgress["engines"    ] = 0.0f;
        researchProgress["weapons"    ] = 0.0f;
        researchProgress["biology"    ] = 0.0f;
        researchProgress["chemistry"  ] = 0.0f;

        techSelection["electronics"] = factory.GetTechLevel("electronics", 1);
        techSelection["energy"     ] = factory.GetTechLevel("energy"     , 1);
        techSelection["engines"    ] = factory.GetTechLevel("engines"    , 1);
        techSelection["weapons"    ] = factory.GetTechLevel("weapons"    , 1);
        techSelection["biology"    ] = factory.GetTechLevel("biology"    , 1);
        techSelection["chemistry"  ] = factory.GetTechLevel("chemistry"  , 1);

        possessedTech["electronics"] = new List<Technology>();
        possessedTech["energy"     ] = new List<Technology>();
        possessedTech["engines"    ] = new List<Technology>();
        possessedTech["weapons"    ] = new List<Technology>();
        possessedTech["biology"    ] = new List<Technology>();
        possessedTech["chemistry"  ] = new List<Technology>();
    }

    public void Turn(float researchPoints) {
        var keys = new List<string>(researchProgress.Keys);
        foreach (var key in keys) {
            researchProgress[key] += (researchPoints * researchSpendingBook[key]) / techSelection[key].GetBaseCost();

            if (researchProgress[key] >= 0.5f) {
                float chance = (float)Math.Pow(2, researchProgress[key] - 0.5f) - 1.0f;

                if (chance > UnityEngine.Random.value) {
                    researchProgress[key] = 0.0f;
                    possessedTech[key].Add(techSelection[key]);

                    // TODO: Provide UI for selecting next tech here, set the appropriate tech level afterwards.
                    techSelection[key] = factory.GetTechLevel(key, techSelection[key].techLevel + 1);
                }
            }
        }
    }
}
