using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing syllables that will form fictional female Demon names.
    public class DemonFemaleNames : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "start",    new List<string>(){
                                                   "Aam", "Ab", "Ad", "Ahr", "Alas", "Al-A'w", "All",
                                                   "Al-M", "Ap", "As", "Ast", "Az", "Bal", "Bal S", "Bag",
                                                   "Balb", "Ban", "Bansh", "Baph", "Barb", "Bath", "Bazt",
                                                   "Be'L", "Beel", "Beelz", "Bel", "Belph", "Ber", "Bh",
                                                   "Bifr", "Biul", "Bush", "Caac", "Cagn", "Caim", "Chalk",
                                                   "Char", "Chem", "Coal", "Dag", "Dant", "Decer", "Demog",
                                                   "Dev", "Dj", "Dragh", "Elig", "Emp", "Errt", "Etr",
                                                   "Ett", "Eur", "Euryn", "Gorg", "Graph", "Grig", "Haag",
                                                   "Halph", "Haur", "Hoeth", "Ifr", "Inc", "Ibl", "Ith",
                                                   "Kabh", "Kas", "Kokb'", "Kray", "Lab", "Lam", "Lech",
                                                   "Leg", "Lil", "Lioth", "Lix", "Luc", "Mal", "Malph",
                                                   "Mamm", "March", "Mast", "Math", "Meph", "Merm", "Mol", 
                                                   "Murm", "Naam", "Naph", "Nek", "Neph", "Neq", "Nix",
                                                   "Noud", "Onom", "Onos", "Orc", "Orob", "Oul", "Paim",
                                                   "Phen", "Pont", "Proc", "Rah", "Rak", "Raksh", "Ram", 
                                                   "Rang", "Raum", "Raz", "Rimm", "Rub", "Rus", "Sabn", 
                                                   "Salps", "Sam", "Sat", "Sc", "Scarm", "Seer", "Sem",
                                                   "Set", "Shait", "Shax", "Shed", "Shez", "Sidr", "Sitr",
                                                   "Sth", "Succ", "Surg", "Tann", "Tart", "Tch", "Teer",
                                                   "Thamm", "Thub", "Tlal", "Tsab", "Val", "Vap", "Vass",
                                                   "Vep", "Verr", "Vin", "Vol", "Vual", "Xaph", "Xiph", 
                                                   "Xitr", "Zaeb", "Zim", "Ziz", "Zaln"
                                                    }
                },
                {
                    "middle", new List<string>(){
                                                    "b'ae", "ba", "be", "chi", "dra", "du", "ga", "ghi",
                                                    "go", "lia", "ma", "mba", "mu", "n'e", "na", "nti",
                                                    "nzu", "phe", "pho", "r'e", "rba", "rgo", "ssa", "thi",
                                                    "tryu", "ttu", "tzi", "v-e", "vna", "xra", "ya"
                                                }
                },
                {
                    "end", new List<string>(){
                                               "b'a", "bel", "bua", "bure", "buth", "cess", "chia", "dai",
                                               "ddea", "dea", "dhaka", "el", "fea", "fla", "gia", "goa",
                                               "gora", "klath", "kore", "ksha", "kua", "laal", "lexa",
                                               "less", "lia", "lith", "loth", "lsa", "mara", "math", "maja",
                                               "mea", "moa", "moth", "mmuth", "mosh", "na", "nai", "neuth",
                                               "nex", "nia", "nnine", "nomoa", "pha", "r'el", "raala", "repte",
                                               "reshe", "rgona", "riaxe", "rith", "rish", "rothe", "rushe",
                                               "ruth", "sia", "stora", "swath", "tath", "thann", "the", "thra",
                                               "trya", "tura", "varte", "ztura"
                                             }
                },
                {
                    "vowels", new List<string>() { 
                                                     "a", "e", "i", "o", "u"
                                                 }
                },
            };

        private static List<string> rules = new List<string>()
            {
                "%100start%100vowels%35middle%10middle%100end"
            };

        public new static List<string> GetSyllableSet(string key) { return syllableSets[key]; }

        public new static List<string> GetRules() { return rules; }   
    }
}
