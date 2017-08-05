using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing syllables that will form fictional fantasy male names that uses different syllables than the other one. Fits any fantasy game.
    //Names based on syllables from J.R.R. Tolkien's and David Eddings' novels.
    public class FantasyMaleNames2 : BaseNames
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
                                                   "Aer", "Al", "Am", "An", "Ar", "Arm",
                                                   "Arth", "B", "Bal", "Bar", "Be", "Bel",
                                                   "Ber", "Bok", "Bor", "Bran", "Breg",
                                                   "Bren", "Brod", "Cam", "Chal", "Cham",
                                                   "Ch", "Cuth", "Dag", "Daim", "Dair",
                                                   "Del", "Dr", "Dur", "Duv", "Ear", "Elen",
                                                   "Er", "Erel", "Erem", "Fal", "Ful", 
                                                   "Gal", "G", "Get", "Gil", "Gor", "Grin",
                                                   "Gun", "H", "Hal", "Han", "Har", "Hath",
                                                   "Hett", "Hur", "Iss", "Khel", "K", "Kor",
                                                   "Lel", "Lor", "M", "Mal", "Man", "Mard",
                                                   "N", "Ol", "Radh", "Rag", "Relg", "Rh", 
                                                   "Run", "Sam", "Tarr", "T", "Tor", "Tul", 
                                                   "Tur", "Ul", "Ulf", "Unr", "Ur", "Urth",
                                                   "Yar", "Z", "Zan", "Zer"
                                                   }
                },
                {
                    "middle",   new List<string>(){ 
                                                    "de", "do", "dra", "du", "duna", "ga",
                                                    "go", "hara", "kaltho", "la", "latha",
                                                    "le", "ma", "nari", "ra", "re", "rego",
                                                    "ro", "rodda", "romi", "rui", "sa", "to",
                                                    "ya", "zila"
                                                   }
                },
                {
                    "end",   new List<string>(){ 
                                                    "bar", "bers", "blek", "chak", "chik", "dan",
                                                    "dar", "das", "dig", "dil", "din", "dir", "dor",
                                                    "dur", "fang", "fast", "gar", "gas", "gen",
                                                    "gorn", "grim", "gund", "had", "hek", "hell", 
                                                    "hir", "hor", "kan", "kath", "khad", "kor", 
                                                    "lach", "lar", "ldil", "ldir", "leg", "len",
                                                    "lin", "mas", "mnir", "ndil", "ndur", "neg", 
                                                    "nik", "ntir", "rab", "rach", "rain", "rak", 
                                                    "ran", "rand", "rath", "rek", "rig", "rim", 
                                                    "rin", "rion", "sin", "sta", "stir", "sus", 
                                                    "tar", "thad", "thel", "tir", "von", "vor",
                                                    "yon", "zor"
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
