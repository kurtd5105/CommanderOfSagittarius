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
        switch (starProperties.color) {
            case StarColor.BLUE:
                break;
            case StarColor.GREEN:
                break;
            case StarColor.PURPLE:
                break;
            case StarColor.RED:
                break;
            case StarColor.WHITE:
                break;
            case StarColor.YELLOW:
                break;
        }
    }
}
