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

	public void Init (Owners playerOwner, String playerRace, String flagName, String CivName, String HomeworldName, String leaderName) {
        this.playerOwner = playerOwner;
        this.playerRace = (Races)System.Enum.Parse(typeof(Races), playerRace);
        this.flagName = flagName;
        this.CivName = CivName;
        this.HomeworldName = HomeworldName;
        this.leaderName = leaderName;
        ownedStars = new Dictionary<uint, Star>();
    }

    public void AddHomeworld(uint id, Star star) {
        ownedStars[id] = star;
        star.starProperties.owner = playerOwner;
    }
}
