using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing syllables that will form fictional fantasy female names. Fits any fantasy game.
    public class FantasyFemaleNames : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "start",    new List<string>(){
                                                   "Aer", "An", "Ar", "Ban", "Bar", "Ber", "Beth", "Bett",
                                                   "Cut", "Dan", "Dar", "Dell", "Der", "Edr", "Er", "Eth",
                                                   "Ett", "Fin", "Ian", "Iarr", "Ill", "Jed", "Kan", "Kar",
                                                   "Ker", "Kurr", "Kyr", "Man", "Mar", "Mer", "Mir", "Tsal",
                                                   "Tser", "Tsir", "Van", "Var", "Yur", "Yyr"
                                                    }
                },
                {
                    "middle", new List<string>(){
                                                    "al", "an", "ar", "el", "en", "ess", "ian", "onn", "or"
                                                }
                },
                {
                    "end", new List<string>(){
                                                "a", "ae", "aelle", "ai", "ea", "i", "ia", "u", "wen", "wyn"
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
