using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResearchManager : MonoBehaviour {
    // Percentage allocation to research spending, from 0.0f - 1.0f, the sum of all values = 1.0f.
    public Dictionary<string, float> researchSpendingBook;
    // RPs that have been allocated in each research location so far.
    public Dictionary<string, float> researchProgress;
    // The tech that each field is currently researching.
    public Dictionary<string, Technology> techSelection;

    // TODO: Add method of tracking researched tech, and initialize it with base tech.

    public void InitAndGenerate() {
        // TODO: Set up each field and research for level 1 tech.
        researchSpendingBook = new Dictionary<string, float>();
        researchProgress = new Dictionary<string, float>();
        techSelection = new Dictionary<string, Technology>();
    }

    public void Turn(float researchPoints) {

    }
}
