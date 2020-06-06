using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFive
{
    public class MinEditDistance
    {
        public static void Init()
        {
        }

        private static int Find(string word1, string word2)
        {
            return Find(word1, word2, word1.Length, word2.Length);
        }

        private static int Find(string word1, string word2, int m, int n)
        {
            var dp = new int[m + 1, n + 1];

            for (var i = 0; i <= m; i++)
            for (var j = 0; j <= n; j++)
                if (i == 0)
                    dp[i, j] = j;
                else if (j == 0)
                    dp[i, j] = i;
                else if (word1[i - 1] == word2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                else
                    dp[i, j] = 1 + Math.Min(Math.Min(dp[i, j - 1], // Insert 
                                       dp[i - 1, j]), // Remove 
                                   dp[i - 1, j - 1]); // Replace 

            return dp[m, n];
        }
    }
}