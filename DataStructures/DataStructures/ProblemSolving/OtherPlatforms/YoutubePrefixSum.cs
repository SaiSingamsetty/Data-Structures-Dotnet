using System.Collections.Generic;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    // Reference : https://www.youtube.com/watch?v=pVS3yhlzrlQ
    // Sum of sub-array of given range
    // Normal Brute Force Approach takes O(M*N) Time complexity to 
    // calculate range queries for given array
    // Prefix sum algorithm solves in O(M+N) at worse

    public class YoutubePrefixSum
    {
        public static void Init()
        {
            var input1 = new[] {6, 3, -2, 4, -1, 0, -5};
            var res1 = FindSum(input1, new[] {new[] {2, 6}, new[] {1, 4}});
        }


        #region Approach 1: Prefix Sum Algorithm : TC: O(M + N)

        private static IEnumerable<int> FindSum(IList<int> arr, IEnumerable<int[]> ranges)
        {
            for (var i = 1; i < arr.Count; i++) arr[i] = arr[i - 1] + arr[i]; // Formed the prefix sum array  O(N)

            var list = new List<int>();

            // Finding range sum for all requested ranges -> O(1) for each => O(M)
            foreach (var range in ranges)
                if (range[0] == 0)
                    list.Add(arr[range[1]]);
                else
                    list.Add(arr[range[1]] - arr[range[0] - 1]);

            return list;
        }

        #endregion
    }
}