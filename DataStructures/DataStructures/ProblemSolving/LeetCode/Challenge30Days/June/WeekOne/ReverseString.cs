namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne
{
    // Challenge 4: https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3350/
    // Write a function that reverses a string. The input string is given as an array of characters char[]. 
    // Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory. 
    // You may assume all the characters consist of printable ascii characters.
    // Example 1:
    // Input: ["h","e","l","l","o"]
    // Output: ["o","l","l","e","h"]
    // Example 2:
    // Input: ["H","a","n","n","a","h"]
    // Output: ["h","a","n","n","a","H"]

    public class ReverseString
    {
        public static void Init()
        {
            var input1 = new[] {'h', 'e', 'a', 'd', 's'};
            ReverseUsingApproach1(input1);

            var input2 = new[] {'h', 'e', 'a', 'd', 'e', 'r'};
            ReverseUsingApproach1(input2);
        }

        private static void ReverseUsingApproach1(char[] s)
        {
            if (s == null || s.Length == 0) return;

            var n = s.Length;
            for (var i = 0; i < n / 2; i++)
            {
                var tmp = s[i];
                s[i] = s[n - i - 1];
                s[n - i - 1] = tmp;
            }
        }
    }
}