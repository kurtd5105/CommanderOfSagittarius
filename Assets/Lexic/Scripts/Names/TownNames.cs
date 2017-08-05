using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing syllables that will form fictional names of towns, based on real world English towns.
    public class TownNames : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "pre",    new List<string>(){
                                                    "East_", "Fort_", "Great_", "High_", "Lower_",
                                                    "Middle_", "Mount_", "New_", "North_", "Old_",
                                                    "Royal_", "Saint_", "South_", "Upper_", "West"
                                                    }
                },
                {
                    "start", new List<string>(){
                                                    "Ales", "Apple", "Ash", "Bald", "Bay", "Bed",
                                                    "Bell", "Birdling", "Black", "Blue", "Bow",
                                                    "Bran", "Brass", "Bright", "Brown", "Bruns",
                                                    "Bulls", "Camp", "Cherry", "Clark", "Clarks", 
                                                    "Clay", "Clear", "Copper", "Corn", "Cross",
                                                    "Crystal", "Dark", "Deep", "Deer", "Drac",
                                                    "Eagle", "Earth", "Elk", "Elles", "Elm", 
                                                    "Ester", "Ewes", "Fair", "Falcon", "Ferry",
                                                    "Fire", "Fleet", "Fox", "Gold", "Grand", 
                                                    "Green", "Grey", "Guild", "Hammer", "Hart",
                                                    "Hawks", "Hay", "Haze", "Hazel", "Hemlock", 
                                                    "Ice", "Iron", "Kent", "Kings", "Knox", 
                                                    "Layne", "Lint", "Lor", "Mable", "Maple",
                                                    "Marble", "Mare", "Marsh", "Mist", "Mor",
                                                    "Mud", "Nor", "Oak", "Orms", "Ox", "Oxen", 
                                                    "Pear", "Pine", "Pitts", "Port", "Purple", 
                                                    "Red", "Rich", "Roch", "Rock", "Rose", 
                                                    "Ross", "Rye", "Salis", "Salt", "Shadow",
                                                    "Silver", "Skeg", "Smith", "Snow", "Sows",
                                                    "Spring", "Spruce", "Staff", "Star", "Steel",
                                                    "Still", "Stock", "Stone", "Strong", "Summer",
                                                    "Swan", "Swine", "Sword", "Yellow", "Val",
                                                    "Wart", "Water", "Well", "Wheat", "White", 
                                                    "Wild", "Winter", "Wolf", "Wool", "Wor"
                                                }
                },
                {
                    "end", new List<string>(){
                                                "bank", "borne", "borough", "brook", "burg",
                                                "burgh", "bury", "castle", "cester", "cliff",
                                                "crest", "croft", "dale", "dam", "dorf", "edge", 
                                                "field", "ford", "gate", "grad", "hall", "ham",
                                                "hollow", "holm", "hurst", "keep", "kirk", "land",
                                                "ley", "lyn", "mere", "mill", "minster", "mont", 
                                                "moor", "mouth", "ness", "pool", "river", "shire", 
                                                "shore", "side", "stead", "stoke", "ston", "thorpe",
                                                "ton", "town", "vale", "ville", "way", "wich", "wick",
                                                "wood", "worth"
                                                }
                },
                {
                    "post", new List<string>(){
                                                "_Annex", "_Barrens", "_Barrow", "_Corner", "_Cove",
                                                "_Crossing", "_Dell", "_Dales", "_Estates", "_Forest",
                                                "_Furnace", "_Grove", "_Haven", "_Heath", "_Hill",
                                                "_Junction", "_Landing", "_Meadow", "_Park", "_Plain",
                                                "_Point", "_Reserve", "_Retreat", "_Ridge", "_Springs",
                                                "_View", "_Village", "_Wells", "_Woods"
                                                }
                },
            };

        private static List<string> rules = new List<string>()
            {
                "%15pre%100start%100end%15post",
            };

        public new static List<string> GetSyllableSet(string key) { return syllableSets[key]; }

        public new static List<string> GetRules() { return rules; }
    }
}
