using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne
{
    // challenge 6: https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3352/
    // Suppose you have a random list of people standing in a queue. Each person is described by a pair of integers (h, k),
    // where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h.
    // Write an algorithm to reconstruct the queue.
    // Input:
    // [[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]
    // Output:
    // [[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]

    public class QueueReconstructionByHeight
    {
        public static void Init()
        {
            var res1 = ConstructUsingApproach1(new[] { new[] { 4, 2 }, new[] { 8, 0 }, new[] { 6, 1 }, new[] { 3, 0 } });
            var res2 = ConstructUsingApproach2(new[] { new[] { 4, 2 }, new[] { 8, 0 }, new[] { 6, 1 }, new[] { 3, 0 } });
            var res3 = ConstructUsingApproach2(new[]
                {new[] {7, 0}, new[] {7, 1}, new[] {6, 1}, new[] {5, 0}, new[] {5, 2}, new[] {4, 4}});
        }

        #region Approach 1

        // Ref: https://www.youtube.com/watch?v=khddrw6Bfyw

        private static int[][] ConstructUsingApproach1(int[][] people)
        {
            // Sort input array in increasing order of heights
            // for the people with same heights, consider second value
            Array.Sort(people, (a, b) =>
            {
                if (a[0] == b[0])
                    return a[1] - b[1];
                return a[0] - b[0];
            });

            var output = new int[people.Length][];

            foreach (var eachPerson in people)
            {
                // no of people in the left side
                var count = eachPerson[1];

                for (var j = 0; j < people.Length; j++)
                {
                    // when the position is blank and counter is 0
                    if (output[j] == null && count == 0)
                    {
                        output[j] = new int[2];
                        output[j][0] = eachPerson[0];
                        output[j][1] = eachPerson[1];
                        break;
                    }

                    // we decrease the counter for two reasons
                    // 1. if the position is blank
                    // 2. if the position is not blank, check that height is significant or not.
                    // for (4,2) insertion, if (3, 0) is present but it is not significant as 3 is less than 4
                    if (output[j] == null || output[j][0] >= eachPerson[0])
                    {
                        count--;
                    }
                }
            }

            return people;
        }

        #endregion

        #region Approach 2 Built-in functions of C#

        private static int[][] ConstructUsingApproach2(int[][] people)
        {
            var n = people.Length;

            var result = new List<int[]>();

            // Sort [[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]
            // To   [[7,0], [7,1], [6,1], [5,0], [5,2], [4,4]]
            Array.Sort(people, (a, b) => a[0] != b[0] ? b[0] - a[0] : a[1] - b[1]);

            foreach (var person in people)
            {
                var height = person[0];
                var index = person[1];

                result.Insert(index, person);
            }

            return result.ToArray();
        }

        #endregion
    }
}
