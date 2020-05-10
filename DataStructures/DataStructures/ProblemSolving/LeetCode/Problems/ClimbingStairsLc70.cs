namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    public class ClimbingStairsLc70
    {
        //LEETCODE 70
        //Ref: https://www.youtube.com/watch?v=NFJ3m9a1oJQ   Back-to-Back SWE (Beautiful explanation on top down and bottom up approaches)


        public static void Init()
        {
            var res1 = FindNoOfWaysUsingApproach1(6);
            var res2 = FindNoOfWaysUsingApproach2(6);
            var res3 = FindNoOfWaysUsingApproach3(6);
        }

        /*
         * Brute Force approach: Calculating sub problems for each problem
         * Time complexity would be nearly O(2^n)
         */

        #region Bottom Up Approach

        /*
         * (Dynamic Programming Array)
           DP is all about caching the answers to previous work and using it in current work.           
           dp[n] denotes the number of ways to climb n steps if we can take 1 or 2 steps.           
           dp[n] = dp[n - 2] + dp[n - 1]
           Time: O( n )
           A for loop making n - 2 iterations           
           Space: O( n )
           We will be holding n + 1 entries in a dp array
         */

        private static int FindNoOfWaysUsingApproach1(int n)
        {
            var memory = new int[n + 1];
            memory[0] = 1; // the only way to do this to do nothing
            memory[1] = 1; // 1 step

            for (var i = 2; i <= n; i++)
            {
                /* Either we can take one step or two steps
                 * If we are calculating for 6, to reach 6,
                 * there are two ways : either 2 steps from 4
                 * or 1 step from 5. So calculating by taking
                 * data of last two possibilities.
                 */
                memory[i] = memory[i - 1] + memory[i - 2];
            }

            return memory[n];
        }

        #endregion

        #region Top Down Approach

        /* Memorization of data into a look up array solving top down style
         * Memorization: If it exists in look up, use that else calculate and save it to look up
         * Time: O( n )
           We cancel out many of the repeated calls that we might have made leading to us to have a linear time complexity.           
           Space: O( n )
           Call stack max depth. And we will still have the dp table.
         */

        private static int[] _lookUp;

        private static int FindNoOfWaysUsingApproach2(int n)
        {
            _lookUp = new int[n + 1];
            RecursionHelperApproach2(n);
            return _lookUp[n];
        }

        private static int RecursionHelperApproach2(int n)
        {
            if (n == -1)
                return 0;
            if (n == 0)
                return 1;

            if (_lookUp[n] > 0)
                return _lookUp[n];

            _lookUp[n] = RecursionHelperApproach2(n - 1) + RecursionHelperApproach2(n - 2);
            return _lookUp[n];
        }

        #endregion

        #region Fibonacci Approach

        private static int FindNoOfWaysUsingApproach3(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            var first = 1;
            var second = 2;

            for (var i = 3; i <= n; i++)
            {
                var third = first + second;
                first = second;
                second = third;
            }

            return second;
        }
    }


    #endregion

}
