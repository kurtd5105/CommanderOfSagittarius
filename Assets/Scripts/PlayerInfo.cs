using System.Collections.Generic;

public class PlayerInfo {
    public Owners playerOwner;
    public Races playerRace;
    public string flagName;
    public string CivName;
    public string HomeworldName;
    public string leaderName;
    public Dictionary<uint, Star> ownedStars;
    public ResearchManager researchManager;

    public PlayerInfo(Owners playerOwner, string playerRace, string flagName, string CivName, string HomeworldName, string leaderName) {
        this.playerOwner = playerOwner;
        this.playerRace = (Races)System.Enum.Parse(typeof(Races), playerRace);
        this.flagName = flagName;
        this.CivName = CivName;
        this.HomeworldName = HomeworldName;
        this.leaderName = leaderName;
        ownedStars = new Dictionary<uint, Star>();

        researchManager = new ResearchManager();

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
