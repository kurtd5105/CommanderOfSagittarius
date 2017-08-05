using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Lexic
{
    public class NameGenerator : MonoBehaviour
    {

        public string namesSourceClass;
        public System.Random rng;

        private List<string> rules;

        private Regex ruleRegex = new Regex(@"^(?<token>(%([0-9]{1,2}|100))([a-z]+))+");
        private Regex tokenRegex = new Regex(@"^%([0-9]{1,2}|100)([a-z]+)");

        void Awake()
        {
            if (rng == null)
                rng = new System.Random();

            System.Type t = System.Type.GetType(namesSourceClass);
            if (t.BaseType != typeof(BaseNames))
                throw new System.ArgumentException(namesSourceClass + " is not a derived class of BaseNames.");

                MethodInfo method = t.GetMethod("GetRules", BindingFlags.Static | BindingFlags.Public);
                if (method == null)
                    throw new System.MissingMethodException("Class "+namesSourceClass+" does not implement GetRules");

                rules = (List<string>)method.Invoke(null, null);
                if (rules.Count <= 0)
                    throw new System.InvalidOperationException("Rule list empty");

            ValidateRules();
        }

        public bool ValidateRules()
        {
            foreach (string rule in rules)
            {
                Match m = ruleRegex.Match(rule);
                if (!m.Success)
                    throw new System.ArgumentException("Rule " + rule +" has incorrect format.");
            }
            return true;
        }

        public string GetNextRandomName()
        {
            string result = "";

            string rule = rules[rng.Next(0, rules.Count)];
            Match rm = ruleRegex.Match(rule);

            CaptureCollection cc = rm.Groups["token"].Captures;

            System.Type t = System.Type.GetType(namesSourceClass);
            MethodInfo method = t.GetMethod("GetSyllableSet", BindingFlags.Static | BindingFlags.Public);
            if (method == null)
                throw new System.MissingMethodException("Class " + namesSourceClass + " does not implement GetSyllableSet");

            for (int i = 0; i < cc.Count; i++)
            {
                Match tm = tokenRegex.Match(cc[i].Value);
                if(tm.Success)
                {
                    int chance = int.Parse(tm.Groups[1].Value);
                    string token = tm.Groups[2].Value;

                    if(rng.Next(0, 99) < chance)
                    {
                        List<string> syllables = (List<string>)method.Invoke(null, new object[] { token });
                        if (syllables.Count <= 0)
                            throw new System.InvalidOperationException("Syllable list for key:"+token+" is empty");
                        result += syllables[rng.Next(0, syllables.Count)];
                    }
                }
            }
               
            return result.Replace("_", " ");
        }

    }
}