using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StarProperties {
    public float population;
    public float factories;
    public float waste;
    public float bases;
    public float reserves;

    // Planet specifics.
    public StarColor color;
    public float maxPopulation;
    public float effectiveMaxPopulation;
    public PlanetTypes planetType;
    public List<PlanetModifiers> planetModifiers;
    public Owners owner;
    public Dictionary<Owners, bool> isExplored;

    public void InitAndGenerate(StarColor color, bool isHomeworld, Owners owner = Owners.NONE) {
        this.color = color;
        planetModifiers = new List<PlanetModifiers>();

        // Generate a new planet based on the star color and if it's a homeworld or not.
        if (isHomeworld) {
            // TODO: These need to vary based on race and difficulty
            population = 50;
            factories = 30;
            maxPopulation = 100;
            planetType = PlanetTypes.TERRAN;
            planetModifiers.Add(PlanetModifiers.NORMAL);
        } else {
            population = 0;
            factories = 0;
            maxPopulation = 0;
            planetType = PlanetTypes.NONE;
            planetModifiers.Add(PlanetModifiers.NORMAL);
            PlanetTypeGenerator.GenerateRandomPlanet(this);
        }

        this.owner = owner;
        bases = 0;
        waste = 0;
        reserves = 0;
        effectiveMaxPopulation = maxPopulation;

        isExplored = new Dictionary<Owners, bool>();
        foreach (var player in System.Enum.GetValues(typeof(Owners)).Cast<Owners>()) {
            isExplored[player] = false;
        }

        if (this.owner != Owners.NONE) {
            isExplored[this.owner] = true;
        }
    }
}
