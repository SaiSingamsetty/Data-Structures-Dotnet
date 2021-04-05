using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Strings
{
    public static class SherlockAndTheValidString
    {
        public static void Execute()
        {
            var res1 = IsValidString("abc"); //Yes
            var res2 = IsValidString("abcc"); //yes
            var res3 = IsValidString("aabbcd"); //no
        }

        private static string IsValidString(string s)
        {
            var lookUp = new Dictionary<char, int>();
            foreach (var eachChar in s)
            {
                if (lookUp.ContainsKey(eachChar))
                {
                    lookUp[eachChar]++;
                }
                else
                {
                    lookUp[eachChar] = 1;
                }
            }
            
            var lookUpValues = lookUp.Values.ToArray();
            Array.Sort(lookUpValues);

            if (lookUpValues.Length == 1)
                return "YES";

            var first = lookUpValues[0];
            var second = lookUpValues[1];
            var secondLast = lookUpValues[lookUpValues.Length - 2];
            var last = lookUpValues[lookUpValues.Length - 1];

            if (first == last)
                return "YES";

            if (first == 1 && second == last)
                return "YES";

            if (first == second && (secondLast + 1) == last)
                return "YES";

            return "NO";
        }
    }
}
