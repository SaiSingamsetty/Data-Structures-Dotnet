using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Arrays
{
    //LEETCODE: https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/769/
    //Determine if a 9x9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
    // 
    // Each row must contain the digits 1-9 without repetition.
    // Each column must contain the digits 1-9 without repetition.
    // Each of the 9 3x3 sub-boxes of the grid must contain the digits 1-9 without repetition.
    public class ValidSudoku
    {
        public static void Init()
        {
            var board = new[]
            {
                new[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };
            var response = IsValidSudoku(board);
            Console.WriteLine(response);
        }

        private static bool IsValidSudoku(char[][] board)
        {
            if (!AreColumnsValid(board)) return false;
            if (!AreRowsValid(board)) return false;
            if (!AreBlocksValid(board)) return false;

            return true;
        }

        private static bool AreRowsValid(char[][] board)
        {
            var size = board.Length;
            for (var i = 0; i < size; i++)
            {
                var hashSet = new HashSet<char>();
                for (var j = 0; j < size; j++)
                {
                    if (!char.IsDigit(board[j][i]))
                    {
                        continue;
                    }

                    if (hashSet.Contains(board[j][i]))
                        return false;

                    hashSet.Add(board[j][i]);
                }
            }

            return true;
        }

        private static bool AreColumnsValid(char[][] board)
        {
            var size = board.Length;
            for (var i = 0; i < size; i++)
            {
                var hashSet = new HashSet<char>();
                for (var j = 0; j < size; j++)
                {
                    if (!char.IsDigit(board[i][j]))
                    {
                        continue;
                    }

                    if (hashSet.Contains(board[i][j]))
                        return false;

                    hashSet.Add(board[i][j]);
                }
            }

            return true;
        }

        private static bool AreBlocksValid(char[][] board)
        {
            var size = board.Length;
            for (var i = 0; i < size / 3; i++)
            {
                for (var j = 0; j < size / 3; j++)
                {
                    var indexI = i * 3;
                    var indexJ = j * 3;
                    if (!CheckBlock(board, indexI, indexJ))
                        return false;
                }
            }

            return true;
        }

        private static bool CheckBlock(char[][] board, int rowIndex, int colIndex)
        {
            var hashSet = new HashSet<char>();
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var indexI = i + rowIndex;
                    var indexJ = j + colIndex;
                    if (!char.IsDigit(board[indexI][indexJ]))
                    {
                        continue;
                    }

                    if (hashSet.Contains(board[indexI][indexJ]))
                        return false;

                    hashSet.Add(board[indexI][indexJ]);
                }
            }

            return true;
        }
    }
}