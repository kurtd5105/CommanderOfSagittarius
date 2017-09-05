using UnityEngine;

public enum PlanetTypes {
    NONE,
    TERRAN,
        DESERT,
        OCEAN,
        ARID,
        STEPPE,
        JUNGLE,
    BARREN,
    TUNDRA,
    INFERNO,
    DEAD,
    TOXIC,
    RADIATED
}

public enum PlanetModifiers {
    NORMAL
}

public enum StarColor {
    YELLOW,
    RED,
    GREEN,
    BLUE,
    PURPLE,
    WHITE
}

static class PlanetTypeGenerator {
    public static void GenerateRandomPlanet(StarProperties starProperties) {
        starProperties.planetType = GetRandomPlanetType(starProperties.color);
        CreatePlanetType(starProperties.planetType, starProperties);
        AddRandomModifiers(starProperties.planetType, starProperties);

        Debug.Log("Planet type: " + starProperties.planetType + " max pop: " + starProperties.maxPopulation);
    }

    private static PlanetTypes GetRandomPlanetType(StarColor color) {
        RandomWeight<PlanetTypes> typeGenerator = new RandomWeight<PlanetTypes>();

        switch (color) {
            case StarColor.BLUE:
                typeGenerator.AddWeight(PlanetTypes.BARREN  , 3);
                typeGenerator.AddWeight(PlanetTypes.DEAD    , 2);
                typeGenerator.AddWeight(PlanetTypes.INFERNO , 2);
                typeGenerator.AddWeight(PlanetTypes.RADIATED, 1);
                typeGenerator.AddWeight(PlanetTypes.TOXIC   , 1);
                break;
            case StarColor.GREEN:
                typeGenerator.AddWeight(PlanetTypes.ARID  , 2);
                typeGenerator.AddWeight(PlanetTypes.BARREN, 1);
                typeGenerator.AddWeight(PlanetTypes.DESERT, 2);
                typeGenerator.AddWeight(PlanetTypes.JUNGLE, 1);
                typeGenerator.AddWeight(PlanetTypes.OCEAN , 1);
                typeGenerator.AddWeight(PlanetTypes.STEPPE, 2);
                typeGenerator.AddWeight(PlanetTypes.TERRAN, 1);
                typeGenerator.AddWeight(PlanetTypes.TUNDRA, 1);
                break;
            case StarColor.PURPLE:
                typeGenerator.AddWeight(PlanetTypes.BARREN  , 1);
                typeGenerator.AddWeight(PlanetTypes.DEAD    , 1);
                typeGenerator.AddWeight(PlanetTypes.INFERNO , 1);
                typeGenerator.AddWeight(PlanetTypes.RADIATED, 3);
                typeGenerator.AddWeight(PlanetTypes.TOXIC   , 2);
                break;
            case StarColor.RED:
                typeGenerator.AddWeight(PlanetTypes.ARID  , 1);
                typeGenerator.AddWeight(PlanetTypes.BARREN, 2);
                typeGenerator.AddWeight(PlanetTypes.DESERT, 3);
                typeGenerator.AddWeight(PlanetTypes.OCEAN , 1);
                typeGenerator.AddWeight(PlanetTypes.STEPPE, 3);
                typeGenerator.AddWeight(PlanetTypes.TUNDRA, 2);
                break;
            case StarColor.WHITE:
                typeGenerator.AddWeight(PlanetTypes.BARREN  , 3);
                typeGenerator.AddWeight(PlanetTypes.DEAD    , 2);
                typeGenerator.AddWeight(PlanetTypes.DESERT  , 2);
                typeGenerator.AddWeight(PlanetTypes.INFERNO , 2);
                typeGenerator.AddWeight(PlanetTypes.RADIATED, 1);
                typeGenerator.AddWeight(PlanetTypes.TOXIC   , 1);
                break;
            case StarColor.YELLOW:
                typeGenerator.AddWeight(PlanetTypes.ARID  , 2);
                typeGenerator.AddWeight(PlanetTypes.DESERT, 1);
                typeGenerator.AddWeight(PlanetTypes.JUNGLE, 3);
                typeGenerator.AddWeight(PlanetTypes.OCEAN , 3);
                typeGenerator.AddWeight(PlanetTypes.STEPPE, 2);
                typeGenerator.AddWeight(PlanetTypes.TERRAN, 3);
                break;
        }

        return typeGenerator.GetRandomKey();
    }

    private static void CreatePlanetType(PlanetTypes type, StarProperties starProperties) {
        RandomWeight<int> popGenerator = new RandomWeight<int>();

        switch (type) {
            case PlanetTypes.TERRAN  :
                popGenerator.AddWeight(100, 4);
                popGenerator.AddWeight(90 , 2);
                popGenerator.AddWeight(80 , 2);
                popGenerator.AddWeight(70 , 1);
                break;
            case PlanetTypes.DESERT  :
                popGenerator.AddWeight(60 , 2);
                popGenerator.AddWeight(50 , 2);
                popGenerator.AddWeight(40 , 2);
                popGenerator.AddWeight(30 , 1);
                break;
            case PlanetTypes.OCEAN   :
                popGenerator.AddWeight(100, 1);
                popGenerator.AddWeight(90 , 2);
                popGenerator.AddWeight(80 , 3);
                popGenerator.AddWeight(70 , 3);
                break;
            case PlanetTypes.ARID    :
                popGenerator.AddWeight(90 , 1);
                popGenerator.AddWeight(80 , 2);
                popGenerator.AddWeight(70 , 3);
                popGenerator.AddWeight(60 , 2);
                popGenerator.AddWeight(50 , 1);
                break;
            case PlanetTypes.STEPPE  :
                popGenerator.AddWeight(60 , 2);
                popGenerator.AddWeight(50 , 3);
                popGenerator.AddWeight(40 , 2);
                popGenerator.AddWeight(30 , 1);
                break;
            case PlanetTypes.JUNGLE  :
                popGenerator.AddWeight(100, 1);
                popGenerator.AddWeight(90 , 3);
                popGenerator.AddWeight(80 , 3);
                popGenerator.AddWeight(70 , 2);
                break;
            case PlanetTypes.BARREN  :
                popGenerator.AddWeight(50 , 3);
                popGenerator.AddWeight(40 , 3);
                popGenerator.AddWeight(30 , 2);
                popGenerator.AddWeight(20 , 1);
                break;
            case PlanetTypes.TUNDRA  :
                popGenerator.AddWeight(50 , 1);
                popGenerator.AddWeight(40 , 2);
                popGenerator.AddWeight(30 , 3);
                popGenerator.AddWeight(20 , 1);
                break;
            case PlanetTypes.INFERNO :
                popGenerator.AddWeight(50 , 1);
                popGenerator.AddWeight(40 , 1);
                popGenerator.AddWeight(30 , 2);
                popGenerator.AddWeight(20 , 2);
                break;
            case PlanetTypes.DEAD    :
                popGenerator.AddWeight(50 , 1);
                popGenerator.AddWeight(40 , 3);
                popGenerator.AddWeight(30 , 2);
                popGenerator.AddWeight(20 , 1);
                break;
            case PlanetTypes.RADIATED:
                popGenerator.AddWeight(40 , 2);
                popGenerator.AddWeight(30 , 1);
                popGenerator.AddWeight(20 , 2);
                popGenerator.AddWeight(10 , 2);
                break;
            case PlanetTypes.TOXIC:
                popGenerator.AddWeight(40 , 2);
                popGenerator.AddWeight(30 , 2);
                popGenerator.AddWeight(20 , 2);
                popGenerator.AddWeight(10 , 1);
                break;
        }

        starProperties.maxPopulation = popGenerator.GetRandomKey();
    }

    private static void AddRandomModifiers(PlanetTypes type, StarProperties starProperties) {

    }
}
