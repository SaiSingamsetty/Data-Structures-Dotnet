using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
    // Challenge 11: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3326/
    // An image is represented by a 2-D array of integers, each integer representing the pixel value of the image (from 0 to 65535). 
    // Given a coordinate (sr, sc) representing the starting pixel (row and column) of the flood fill, and a pixel value newColor, "flood fill" the image. 
    // To perform a "flood fill", consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color as the starting pixel), and so on. Replace the color of all of the aforementioned pixels with the newColor.
    // At the end, return the modified image.
    // Input: 
    // image = [[1,1,1],[1,1,0],[1,0,1]]
    // sr = 1, sc = 1, newColor = 2
    // Output: [[2,2,2],[2,2,0],[2,0,1]]
    // Explanation: 
    // From the center of the image (with position (sr, sc) = (1, 1)), all pixels connected 
    // by a path of the same color as the starting pixel are colored with the new color.
    // Note the bottom corner is not colored 2, because it is not 4-directionally connected
    // to the starting pixel.

    // NOTES
    // * The length of image and image[0] will be in the range [1, 50].
    // * The given starting pixel will satisfy 0 <= sr < image.length and 0 <= sc < image[0].length.
    // * The value of each color in image[i][j] and newColor will be an integer in [0, 65535]
    public class FloodFill
    {
        public static void Init()
        {
            Console.WriteLine("Test Case 1");
            var arr = new int[3][];
            arr[0] = new[] {1, 1, 0, 0};
            arr[1] = new[] {0, 0, 1, 1};
            arr[2] = new[] {1, 1, 1, 0};
            PrintMatrix(arr);
            var res1 = FloodFillApproach1(arr, 0, 0, 7);
            Console.WriteLine("After flooding");
            PrintMatrix(res1);

            Console.WriteLine("Test Case 2");
            var arr2 = new int[3][];
            arr2[0] = new[] {1, 1, 1};
            arr2[1] = new[] {1, 1, 0};
            arr2[2] = new[] {1, 0, 1};
            PrintMatrix(arr2);
            var res2 = FloodFillApproach1(arr2, 1, 1, 2);
            Console.WriteLine("After flooding");
            PrintMatrix(res2);
        }

        /* Helper Method to print the matrix */
        private static void PrintMatrix(int[][] image)
        {
            foreach (var eachRow in image)
            {
                for (var j = 0; j < image[0].Length; j++)
                {
                    Console.Write(eachRow[j] + " ");
                }

                Console.WriteLine("\n");
            }
        }

        #region Approach 1: Using Recursion

        // Ref: //https://github.com/chetanbommu/LeetCode-MayChallenge2020/blob/master/src/FloodFill.java

        private static int[][] FloodFillApproach1(int[][] image, int sr, int sc, int newColor)
        {
            var oldColor = image[sr][sc];
            if (oldColor == newColor)
                return image;
            Approach1RecursionHelper(image, sr, sc, newColor, oldColor);

            return image;
        }

        private static void Approach1RecursionHelper(int[][] image, int sr, int sc, int newColor, int oldColor)
        {
            if (image[sr][sc] == oldColor)
            {
                image[sr][sc] = newColor;
                if (sc + 1 < image[0].Length)
                    Approach1RecursionHelper(image, sr, sc + 1, newColor, oldColor);
                if (sc - 1 >= 0)
                    Approach1RecursionHelper(image, sr, sc - 1, newColor, oldColor);
                if (sr + 1 < image.Length)
                    Approach1RecursionHelper(image, sr + 1, sc, newColor, oldColor);
                if (sr - 1 >= 0)
                    Approach1RecursionHelper(image, sr - 1, sc, newColor, oldColor);
            }
        }

        #endregion
    }
}