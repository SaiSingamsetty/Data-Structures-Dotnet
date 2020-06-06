namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    // Leetcode 413: https://leetcode.com/problems/arithmetic-slices/
    // A sequence of number is called arithmetic if it consists of at least three elements and if the difference between any two consecutive elements is the same.
    // For example, these are arithmetic sequence:
    // 1, 3, 5, 7, 9
    // 7, 7, 7, 7
    // 3, -1, -5, -9
    // The following sequence is not arithmetic.
    // 1, 1, 2, 5, 7
    // A zero-indexed array A consisting of N numbers is given. A slice of that array is any pair of integers (P, Q) such that 0 <= P < Q < N.
    // A slice (P, Q) of array A is called arithmetic if the sequence:
    // A[P], A[p + 1], ..., A[Q - 1], A[Q] is arithmetic. In particular, this means that P + 1 < Q.
    // The function should return the number of arithmetic slices in the array A.

    public class ArithmeticSlicesLc413
    {
        public static void Init()
        {
            var res1 = FindUsingApproach1(new[] {1, 3, 5, 7, 9});
            var res2 = FindUsingApproach2(new[] {1, 3, 5, 7, 9});
            var res3 = FindUsingApproach3(new[] {1, 3, 5, 7, 9});
            var res4 = FindUsingApproach4(new[] {1, 3, 5, 7, 9});
        }

        #region Approach 1: Brute Force TC: O(N2), SC: O(1)

        private static int FindUsingApproach1(int[] A)
        {
            var count = 0;
            for (var s = 0; s < A.Length - 2; s++)
            {
                var d = A[s + 1] - A[s];
                for (var e = s + 2; e < A.Length; e++)
                    if (A[e] - A[e - 1] == d)
                        count++;
                    else
                        break;
            }

            return count;
        }

        #endregion

        #region Approach 3: Dynamic Programming TC, SC: O(N)

        private static int FindUsingApproach3(int[] A)
        {
            var dp = new int[A.Length];
            var sum = 0;
            for (var i = 2; i < dp.Length; i++)
            {
                if (A[i] - A[i - 1] != A[i - 1] - A[i - 2])
                    continue;

                dp[i] = 1 + dp[i - 1];
                sum += dp[i];
            }

            return sum;
        }

        #endregion

        #region Approach 4: Dynamic Programming With Constant Space TC: O(N), SC: O(1)

        private static int FindUsingApproach4(int[] A)
        {
            var dp = 0;
            var sum = 0;
            for (var i = 2; i < A.Length; i++)
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                {
                    dp = 1 + dp;
                    sum += dp;
                }
                else
                {
                    dp = 0;
                }

            return sum;
        }

        #endregion

        #region Approach 2: Recursion TC: O(N), SC: O(N)

        private static int _sum;

        private static int FindUsingApproach2(int[] A)
        {
            SliceHelperForApproach2(A, A.Length - 1);
            return _sum;
        }

        private static int SliceHelperForApproach2(int[] A, int i)
        {
            if (i < 2)
                return 0;
            var ap = 0;
            if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
            {
                ap = 1 + SliceHelperForApproach2(A, i - 1);
                _sum += ap;
            }
            else
            {
                SliceHelperForApproach2(A, i - 1);
            }

            return ap;
        }

        #endregion
    }
}