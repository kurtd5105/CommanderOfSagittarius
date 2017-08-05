using System.Collections.Generic;

namespace Lexic
{
    //An example of what a dictionary could contain and what the rules could look like. Will not generate anything meaningful.
    public class ExampleNames : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "start",    new List<string>(){
                                                    "a", "ab", "abc",
                                                    }
                },
                {
                    "middle",   new List<string>(){
                                                    "b", "bc", "bcd",
                                                    }
                },
                {
                    "end",      new List<string>(){
                                                    "c", "cd", "cde",
                                                    }
                },
            };

        private static List<string> rules = new List<string>()
            {
                "%100start%100middle%100end", "%100start%100end", "%100start%50middle%75end",
            };

        public new static List<string> GetSyllableSet(string key) { return syllableSets[key]; }

        public new static List<string> GetRules() { return rules; }   
    }
}
