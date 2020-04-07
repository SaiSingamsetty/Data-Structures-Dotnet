using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days
{
    //LEETCODE: Challenge6 https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/528/week-1/3288/
    //Given an array of strings, group anagrams together.
    /*
     * Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
       Output:
       [
       ["ate","eat","tea"],
       ["nat","tan"],
       ["bat"]
       ]
     */


    public class GroupAnagrams
    {
        public static void Init()
        {
            var strArray = new[] {"eat", "tea", "tan", "ate", "nat", "bat"};
            var response = Group(strArray);
            Console.WriteLine(string.Join(',', response.SelectMany(x => x)));
        }

        private static IList<IList<string>> Group(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                var val = new string(str.Select(r => r).OrderBy(x => x).ToArray());
                if (dict.ContainsKey(val))
                {
                    dict[val].Add(str);
                }
                else
                {
                    dict.Add(val, new List<string>() {str});
                }
            }

            return dict.Values.ToList();
        }
    }
}