using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing syllables that will form fictional male Celtic names.
    public class CelticMaleNames : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "start",    new List<string>(){
                                                    "Aen", "Agno", "All", "Ba", 
                                                    "Beo", "Brig", "Ci", "Cre", 
                                                    "Dan", "Del", "Ela", "Eo", 
                                                    "En", "Er", "Et", "In", "Io", 
                                                    "Morr", "Nem", "Nu", "Og", 
                                                    "Or", "Ta"
                                                    }
                },
                {
                    "middle", new List<string>(){
                                                    "a", "ar", "ba", "bo", "ch", "d", "ig"
                                                }
                },
                {
                    "end", new List<string>(){
                                                "aid", "ain", "an", "and", "th", "ed", "eth", 
                                                "gus", "lam", "lor", "man", "od", "t", "thach"
                                             }
                },
            };

        private static List<string> rules = new List<string>()
            {
                "%100start%100end", "%100start%100middle%100end"
            };

        public new static List<string> GetSyllableSet(string key) { return syllableSets[key]; }

        public new static List<string> GetRules() { return rules; }   
    }
}
