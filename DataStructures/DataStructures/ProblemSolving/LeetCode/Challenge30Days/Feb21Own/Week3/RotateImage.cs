using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.Feb21Own.Week3
{
    // https://leetcode.com/problems/rotate-image/
    public class RotateImage
    {
        public static void Execute()
        {
            var mat1 = new[] {new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {7, 8, 9}};
            Rotate(mat1);
        }

        private static int[][] Rotate(int[][] matrix)
        {
            // 90 Degree right rotation => Transpose + Reflect
            // 90 Degree left rotation => Reflect + Transpose
            
            Transpose(matrix);
            Reflect(matrix);
            //Transpose(matrix);
            
            return matrix;
        }

        private static void Transpose(int[][] matrix)
        {
            var size = matrix.Length;

            for (var i = 0; i < size; i++)
            {
                for (var j = i; j < size; j++)
                {
                    if (i == j) continue;
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        private static void Reflect(int[][] matrix)
        {
            var size = matrix.Length;

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size / 2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][size-j-1];
                    matrix[i][size - j - 1] = temp;
                }
            }
        }

    }
}
