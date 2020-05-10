using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May10
{
    // TIME LIMIT EXCEEDED IN BOTH APPROACHES

    // LC 1442
    // https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/
    // Given an array of integers arr.
    // We want to select three indices i, j and k where (0 <= i < j <= k < arr.length).
    // Let's define a and b as follows:
    // a = arr[i] ^ arr[i + 1] ^ ... ^ arr[j - 1]
    // b = arr[j] ^ arr[j + 1] ^ ... ^ arr[k]
    // Note that ^ denotes the bitwise-xor operation.
    // Return the number of triplets (i, j and k) Where a == b.

    public class CountTriplets
    {
        private static List<Possibility> _possibilities;

        public static void Init()
        {
            var res1 = CountUsingApproach2(new[] {2, 3, 1, 6, 7});
            var res2 = Count(new[] {2, 3});
            var res3 = Count(new[] {7, 11, 12, 9, 5, 2, 7, 17, 22});
        }


        private static int Count(int[] arr)
        {
            var counter = 0;
            var length = arr.Length;
            var i = 0;

            while (i < length - 1)
            {
                var j = i + 1;
                while (j < length)
                {
                    var k = j;
                    while (k < length)
                    {
                        var a = FindXor(arr, i, j - 1);
                        var b = FindXor(arr, j, k);

                        if (a == b)
                            counter++;
                        k++;
                    }

                    j++;
                }

                i++;
            }

            return _possibilities.Count;
        }

        private static int FindXor(int[] arr, int pointer1, int pointer2)
        {
            var res = 0;

            while (pointer1 <= pointer2 && pointer2 < arr.Length)
            {
                res = res ^ arr[pointer1];
                pointer1++;
            }

            return res;
        }

        private static int CountUsingApproach2(int[] arr)
        {
            _possibilities = new List<Possibility>();
            var length = arr.Length;
            var i = 0;

            while (i < length - 1)
            {
                var k = i + 1;
                while (k < length)
                {
                    var res = FindXor(arr, i, k);
                    if (res == 0)
                    {
                        FindPossibilities(i, k);
                    }

                    k++;
                }

                i++;
            }

            return _possibilities.Count;
        }

        private static void FindPossibilities(int pointer1, int pointer2)
        {
            var j = pointer1 + 1;
            while (j <= pointer2)
            {
                var exists = _possibilities.Any(x => x.I == pointer1 && x.J == j && x.K == pointer2);
                if (!exists)
                    _possibilities.Add(new Possibility()
                    {
                        I = pointer1,
                        J = j,
                        K = pointer2
                    });
                j++;
            }
        }
    }

    public class Possibility
    {
        public int I { get; set; }

        public int J { get; set; }

        public int K { get; set; }
    }
}