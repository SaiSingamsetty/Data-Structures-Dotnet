namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.Feb21Own.Week3
{
    //https://leetcode.com/problems/number-of-1-bits/
    
    public class NumberOf1Bits
    {
        public static void Execute()
        {
            var ut1 = HammingWeightByLoop(00000000000000000000000000001011);
            var ut2 = HammingWeightByBitManipulationTrick(00000000000000000000000000001011);
        }

        private static int HammingWeightByLoop(uint n)
        {
            var counter = 0;
            var mask = 1;
            for (var i = 0; i < 32; i++)
            {
                if ((n & mask) != 0)
                {
                    counter++;
                }

                mask <<= 1;
            }
            
            return counter;
        }

        private static int HammingWeightByBitManipulationTrick(uint n)
        {
            var sum = 0;
            while (n != 0)
            {
                sum++;
                n = n & (n - 1);
            }
            return sum;
        }
    }
}
