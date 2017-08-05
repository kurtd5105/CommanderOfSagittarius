using System.Collections.Generic;

namespace Lexic
{
    //Base dictionary class from which all dictionaries must inherit. These two methods must
    //be implemented as well.
    public class BaseNames
    {
        //Returns a list of syllables for a given key.
        public static List<string> GetSyllableSet(string key) { throw new System.NotImplementedException();  }

        //Returns a list of rules.
        //Each rule must be a string in the form of:
        // %<chance><token>%<chance2><token2>...
        //Where "chance" is the probability of "token" being added to the word in this position
        //"Chance" must be an integer number from 0 to 100, inclusive
        //"Token" must be a string of characters where underscore replaces spaces. All underscores
        //will be converted to spaces in the procedurally generated name.
        public static List<string> GetRules() { throw new System.NotImplementedException(); }
    }
}
