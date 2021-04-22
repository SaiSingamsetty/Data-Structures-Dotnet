using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank
{
    public static class LengthOfPositiveProduct
    {
        //FindMaxProduct: https://www.youtube.com/watch?v=vtJvbRlHqTA


        public static void Execute()
        {
            //Get length of max product sub-array
            var res1 = Find(new[] { 1, -2, -3, 4 }); // 4 (1, -2, -3, 4)
            var res2 = Find(new[] { 2, -3, 5 }); //1 (5)
            var res3 = Find(new[] { 2, 3, -2, 4 }); //6 (2)

            var res4 = FindMaxProduct(new[] { -1, -2, -9, -6}); //6 (2)
        }

        private static int FindMaxProduct(int[] arr)
        {
            var prevMaxProd = arr[0];
            var prevMinProd = arr[0];

            var output = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                //Max of (curr element being positive), (current element being negative), (curr element if prev element is 0 case)
                var currMaxProd = MaxOf(prevMaxProd * arr[i], prevMinProd * arr[i], arr[i]);

                //Min of (curr element being positive), (current element being negative), (curr element if prev element is 0 case)
                var currMinProd = MinOf(prevMaxProd * arr[i], prevMinProd * arr[i], arr[i]);

                output = Math.Max(output, currMaxProd);

                prevMaxProd = currMaxProd;
                prevMinProd = currMinProd;
            }

            return output;
        }

        private static int MaxOf(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        private static int MinOf(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        private static int Find(int[] nums)
        {
            int positive = 0, negative = 0;    // length of positive and negative results
            int ans = 0;
            foreach (var x in nums)
            {
                if (x == 0)
                {
                    positive = 0;
                    negative = 0;
                }
                else if (x > 0)
                {
                    positive++;
                    negative = negative == 0 ? 0 : negative + 1;
                }
                else
                {
                    int temp = positive;
                    positive = negative == 0 ? 0 : negative + 1;
                    negative = temp + 1;
                }
                ans = Math.Max(ans, positive);
            }
            return ans;
        }
    }
}
