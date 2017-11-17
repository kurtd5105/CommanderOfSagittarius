public class Technology {
    // The amount of RP required to research a tech is based off the tech level.
    public int techLevel;
    public string techName;

    public Technology(string name, int level) {
        techLevel = level;
        techName = name;
    }

    public int GetBaseCost() {
        return techLevel * 100;
    }
}
