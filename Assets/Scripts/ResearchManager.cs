using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResearchManager {
    // Percentage allocation to research spending, from 0.0f - 1.0f, the sum of all values = 1.0f.
    public Dictionary<string, float> researchSpendingBook;
    // RPs that have been allocated in each research location so far.
    public Dictionary<string, float> researchProgress;
    // The tech that each field is currently researching.
    public Dictionary<string, Technology> techSelection;

    // TODO: Add method of tracking researched tech, and initialize it with base tech.
    private TechnologyFactory factory;

    public void InitAndGenerate(TechnologyFactory factory) {
        // TODO: make this able to be retrieved with a getter.
        this.factory = factory;
        // TODO: Set up each field and research for level 1 tech.
        researchSpendingBook = new Dictionary<string, float>();
        researchProgress = new Dictionary<string, float>();
        techSelection = new Dictionary<string, Technology>();

        researchSpendingBook["electronics"] = 16.0f;
        researchSpendingBook["energy"     ] = 16.0f;
        researchSpendingBook["engines"    ] = 16.0f;
        researchSpendingBook["weapons"    ] = 16.0f;
        researchSpendingBook["biology"    ] = 18.0f;
        researchSpendingBook["chemistry"  ] = 18.0f;

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
    }

    public void Turn(float researchPoints) {

    }
}
