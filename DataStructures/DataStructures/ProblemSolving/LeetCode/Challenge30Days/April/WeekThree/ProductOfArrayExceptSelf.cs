using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekThree
{
    public class ProductOfArrayExceptSelf
    {
        public static void Init()
        {
            var arr = new[] {1, 2, 3, 4};
            Console.WriteLine(string.Join(',', FindProductOfArrayUsingOneArray(arr)));
        }

        // Time : 2 * O(N), Space : 1 extra array
        private static int[] FindProductOfArrayUsingOneArray(int[] nums)
        {
            var length = nums.Length;
            var pre = new int[length];
            var temp = 1;

            //In this loop, temp variable contains product of elements on left side excluding arr[i]
            for (var i = 0; i < length; i++)
            {
                pre[i] = temp;
                temp = temp * nums[i];
            }

            temp = 1;
            // In this loop, temp variable contains product of elements on right side excluding arr[i]
            for (var i = length - 1; i >= 0; i--)
            {
                pre[i] = pre[i] * temp;
                temp = temp * nums[i];
            }

            return pre;
        }

        //For better understanding
        //Time : 3 * O(N) , 2 extra arrays
        private static int[] FindProductOfArrayUsingTwoArrays(int[] nums)
        {
            var length = nums.Length;
            var pre = new int[length];
            var post = new int[length];
            var temp = 1;

            //In this loop, temp variable contains product of elements on left side excluding arr[i]
            for (var i = 0; i < length; i++)
            {
                pre[i] = temp;
                temp = temp * nums[i];
            }

            temp = 1;
            // In this loop, temp variable contains product of elements on right side excluding arr[i]
            for (var i = length - 1; i >= 0; i--)
            {
                post[i] = temp;
                temp = temp * nums[i];
            }

            for (var i = 0; i < length; i++) pre[i] = pre[i] * post[i];

            return pre;
        }
    }
}