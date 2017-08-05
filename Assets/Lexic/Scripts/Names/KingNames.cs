using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing syllables that will form semi-historical names of kings, along with their titles. Fits any "alternate-history" RPG or strategy game.
    public class KingNames : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "firstnames",    new List<string>(){
                                                    "Alexander_", "Augustus_", "Casimir_",
                                                    "Henry_", "John_", "Louis_",
                                                    "Sigismund_", "Stanislaw_", "Stephen_",
                                                    "Wenceslaus_", "Edward_", "Alfred_", "Charles_",
                                                    "Edgar_", "Harold_", "William_", "Richard_", "Philip_",
                                                    "James_", "Dagobert_", "Theuderic_", "Robert_",
                                                    "Rudolf_", "Lothar_", "Hugo_", "Francis_", 
                                                    "Edmund_", "Ragnvald_", "Magnus_", "Albert_", 
                                                    "Sigmund_", "Gustav_", "Frederick_", "Oscar_",
                                                    "Lech_", "Boleslaw_", 
                                                    }
                },
                {
                    "numbers",   new List<string>(){
                                                    "I_", "II_", "III_", "IV_", "V_", "VI_", "VII_",
                                                    "VIII_", "IX_", "X_", "XI_", "XII_", "XIII_",
                                                    "XIV_", "XV_", "XVI_"
                                                    }
                },
                {
                    "titles",      new List<string>(){
                                                   "Bathory", "Herman", "Jogaila", "Lambert", "of_Bohemia", "of_France",
                                                    "of_Hungary", "of_Masovia", "of_Poland", "of_Valois", "of_Varna", "Probus",
                                                    "Spindleshanks", "Tanglefoot", "the_Bearded", "the_Black", "the_Bold", "the_Brave",
                                                    "the_Chaste", "the_Curly", "the_Elbow-high", "the_Exile", "the_Great",
                                                    "the_Jagiellonian", "the_Just", "the_Old", "the_Pious", "the_Restorer", "the_Saxon",
                                                    "the_Strong", "the_Wheelwright", "the_White", "Vasa", "Wrymouth", "the_Elder",
                                                    "the_Peaceful", "the_Martyr", "the_Unready", "Forkbeard", "Ironside",
                                                    "Harefoot", "the_Confessor", "the_Young", "the_Victorious", "the_Old",
                                                    "the_Red", "the_Younger", "the_Lame", "Barnlock", "of_Sweden", "of_Lithuania",
                                                    "the_Tyrant", "Bourbon", "Savoy", "Habsburg", 
                                                    }
                },
            };

        private static List<string> rules = new List<string>()
            {
                "%100firstnames%100numbers", "%100firstnames%50numbers%100titles", "%100firstnames%100titles",
            };

        public new static List<string> GetSyllableSet(string key) { return syllableSets[key]; }

        public new static List<string> GetRules() { return rules; }
    }
}
