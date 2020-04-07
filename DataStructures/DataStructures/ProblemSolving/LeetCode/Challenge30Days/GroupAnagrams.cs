using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days
{
    public class GroupAnagrams
    {
        public static void Init()
        {
            var strArray = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var response = Group(strArray);
            Console.WriteLine(string.Join(',', response.SelectMany(x => x)));
        }

        private static IList<IList<string>> Group(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                var val =  new string(str.Select(r => r).OrderBy(x => x).ToArray());
                if (dict.ContainsKey(val))
                {
                    dict[val].Add(str);
                }
                else
                {
                    dict.Add(val, new List<string>() { str });
                }
            }
            
            return dict.Values.ToList();
        }
        
    }
}
