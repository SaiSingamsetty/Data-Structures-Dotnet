using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekFour
{
    // Challenge28: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/531/week-4/3313/
    // https://www.youtube.com/watch?v=x_m69OeOHN8
    // You have a queue of integers, you need to retrieve the first unique integer in the queue.
    // Implement the FirstUnique class:
    // FirstUnique(int[] nums) Initializes the object with the numbers in the queue.
    // int showFirstUnique() returns the value of the first unique integer of the queue, and returns -1 if there is no such integer.
    // void add(int value) insert value to the queue.

    public class FirstUniqueNumber
    {
        private readonly Dictionary<int, int> _dictionary;

        private readonly Queue<int> _queue;

        //Time complexity: O(N)
        public FirstUniqueNumber(int[] nums)
        {
            _queue = new Queue<int>();
            _dictionary = new Dictionary<int, int>();

            foreach (var eachNum in nums)
            {
                if (_dictionary.ContainsKey(eachNum))
                    _dictionary[eachNum]++;
                else
                {
                    _dictionary.Add(eachNum, 1);
                }

                _queue.Enqueue(eachNum);
            }
        }

        public static void Init()
        {
            var obj = new FirstUniqueNumber(new int[] {2, 3, 5});
            var s1 = obj.ShowFirstUnique();
            obj.Add(5);
            var s2 = obj.ShowFirstUnique();
            obj.Add(2);
            var s3 = obj.ShowFirstUnique();
            obj.Add(3);
            var s4 = obj.ShowFirstUnique();
        }

        //Time complexity: O(max(Q,N)) Q : no of elements skipped
        public int ShowFirstUnique()
        {
            if (_queue.Count == 0)
                return -1;

            var val = _queue.Peek();
            while (_dictionary.ContainsKey(val) && _dictionary[val] > 1 && _queue.Count > 0)
            {
                _queue.Dequeue();
                val = _queue.Count == 0 ? -1 : _queue.Peek();
            }

            return val;
        }

        //Time complexity: O(1)
        public void Add(int value)
        {
            if (_dictionary.ContainsKey(value))
            {
                _dictionary[value]++;
            }
            else
            {
                _queue.Enqueue(value);
                _dictionary.Add(value, 1);
            }
        }
    }
}