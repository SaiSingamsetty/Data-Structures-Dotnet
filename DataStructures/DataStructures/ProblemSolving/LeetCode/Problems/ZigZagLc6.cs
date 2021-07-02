using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    //https://leetcode.com/problems/zigzag-conversion/

    public static class ZigZagLc6
    {
        public static void Execute()
        {
            var res1 = Find1("PAYPALISHIRING", 3); //PAHNAPLSIIGYIR
            /*
               P   A   H   N
               A P L S I I G
               Y   I   R   
             */
        }

        /*
        Time Complexity: O(n)O(n), where n == \text{len}(s)n==len(s)
        Space Complexity: O(n)O(n)  
         */
        private static string Find1(string s, int numRows)
        {
            if (numRows == 1) return s;

            //for each row, prepare a string builder
            var rows = new List<StringBuilder>();
            for (var i = 0; i < Math.Min(numRows, s.Length); i++)
            {
                rows.Add(new StringBuilder());
            }

            var curRow = 0;
            var goingDown = false;

            foreach (var c in s.ToCharArray())
            {
                //Add char to current row
                rows[curRow].Append(c);

                //we have to change direction only
                //when we moved up to the topmost row or moved down to the bottommost row.
                if (curRow == 0 || curRow == numRows - 1)
                {
                    goingDown = !goingDown;
                }

                //If goingDown is true - increment by 1 else decrease by 1
                curRow += goingDown ? 1 : -1;
            }

            var ret = new StringBuilder();
            foreach(var row in rows) ret.Append(row);
            return ret.ToString();
        }
    }
}
