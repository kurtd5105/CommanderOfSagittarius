using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing syllables that will form fictional fantasy female names that uses different syllables than the other one. Fits any fantasy game.
    //Names based on syllables from J.R.R. Tolkien's and David Eddings' novels.
    public class FantasyFemaleNames2 : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "vowels",   new List<string>(){ 
                                                    "a", "e", "i", "o", "u", "y"
                                                   }
                },
                {
                    "consonants",   new List<string>(){ 
                                                    "b", "c", "ch", "ck", "cz", "d",
                                                    "dh", "f", "g", "gh", "h", "j",
                                                    "k", "kh", "l", "m", "n", "p",
                                                    "ph", "q", "r", "rh", "s", "sh",
                                                    "t", "th", "ts", "tz", "v", "w",
                                                    "x", "z", "zh"
                                                   }
                },
                {
                    "start",   new List<string>(){ 
                                                   "Ad", "Aer", "Ar", "Bel", "Bet", "Beth",
                                                   "Ce'N", "Cyr", "Eilin", "El", "Em", "Emel",
                                                   "G", "Gl", "Glor", "Is", "Isl", "Iv", "Lay",
                                                   "Lis", "May", "Ner", "Pol", "Por", "Sal",
                                                   "Sil", "Vel", "Vor", "X", "Xan", "Xer",
                                                   "Yv", "Zub"
                                                   }
                },
                {
                    "middle",   new List<string>(){ 
                                                    "bre", "da", "dhe", "ga", "lda", "le", "lra",
                                                    "mi", "ra", "ri", "ria", "re", "se", "ya"
                                                   }
                },
                {
                    "end",   new List<string>(){ 
                                                    "ba", "beth", "da", "kira", "laith", "lle",
                                                    "ma", "mina", "mira", "na", "nn", "nne", "nor",
                                                    "ra", "rin", "ssra", "ta", "th", "tha", "thra", 
                                                    "tira", "tta", "vea", "vena", "we", "wen", "wyn"
                                                   }
                },
                
            };

        private static List<string> rules = new List<string>()
            {
                "%100start%100vowels%35middle%10middle%100end",
            };

        public new static List<string> GetSyllableSet(string key) { return syllableSets[key]; }

        public new static List<string> GetRules() { return rules; }   
    }
}
