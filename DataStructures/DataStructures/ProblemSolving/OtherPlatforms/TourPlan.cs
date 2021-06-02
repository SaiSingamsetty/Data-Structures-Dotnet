using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    public static class TourPlan
    {
        //Problem Statement: https://drive.google.com/file/d/1hYEqdLh7-Xu9zoEeNen7OiWNEFgf8RyF/view?usp=sharing

        public static void Execute()
        {
            var r1 = Find(new[] {7, 5, 2, 7, 2, 7, 4, 7}); //6 - (1 - 6)
            var r2 = Find(new[] { 2, 1, 1, 3, 2, 1, 1, 3 }); //3 - (2 - 4)
        }

        private static int _counter = int.MaxValue;

        private static int Find(int[] A)
        {
            var hashSet = new HashSet<int>();
            foreach (var i in A)
            {
                hashSet.Add(i);
            }

            var lookUp = new Dictionary<int, int>();
            int j = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (; j < A.Length; j++)
                {
                    if (lookUp.ContainsKey(A[j]))
                    {
                        lookUp[A[j]] += 1;
                    }
                    else
                    {
                        lookUp.Add(A[j], 1);
                    }

                    var isMatch = IsAMatch(hashSet, lookUp.Keys.ToList(), i, j);
                    
                    while (isMatch && j > i)
                    {
                        UpdateLookUp(lookUp, A[i]);
                        i++;

                        var isMatchAgain = IsAMatch(hashSet, lookUp.Keys.ToList(), i, j);
                        if (!isMatchAgain)
                            break;
                    }

                }

            }

            return _counter;
        }

        private static bool IsAMatch(HashSet<int> set, List<int> keys, int i, int j)
        {
            var isMatch = keys.Count == set.Count;
            if (isMatch)
            {
                if ((j - i) + 1 < _counter)
                {
                    _counter = (j - i) + 1;
                }
            }

            return isMatch;
        }

        private static void UpdateLookUp(Dictionary<int, int> lookUp, int key)
        {
            if (lookUp.ContainsKey(key))
            {
                if (lookUp[key] == 1)
                {
                    lookUp.Remove(key);
                }
                else
                {
                    lookUp[key] -= 1;
                }
            }
        }
    }
}