using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo {

    public Owners playerOwner;
    public Races playerRace;
    public String flagName;
    public String CivName;
    public String HomeworldName;
    public String leaderName;
    public Dictionary<uint, Star> ownedStars;
    public ResearchManager researchManager;

	public void Init (Owners playerOwner, String playerRace, String flagName, String CivName, String HomeworldName, String leaderName, TechnologyFactory factory) {
        this.playerOwner = playerOwner;
        this.playerRace = (Races)System.Enum.Parse(typeof(Races), playerRace);
        this.flagName = flagName;
        this.CivName = CivName;
        this.HomeworldName = HomeworldName;
        this.leaderName = leaderName;
        ownedStars = new Dictionary<uint, Star>();

        researchManager = new ResearchManager(factory);

        ButtonManager.NextTurn += Turn;
        ButtonManager.NextTurnResearch += DoResearch;
    }

    public void AddHomeworld(uint id, Star star) {
        ownedStars[id] = star;
        star.starProperties.owner = playerOwner;
    }

    public void Turn() {

    }

    public void DoResearch() {
        float researchPoints = 0.0f;

        foreach (var star in ownedStars.Values) {
            researchPoints += star.GetResearchPointsProduced();
        }

        researchManager.Turn(researchPoints);
    }

    private void OnDestroy() {
        ButtonManager.NextTurn -= Turn;
        ButtonManager.NextTurnResearch -= DoResearch;
    }
}
