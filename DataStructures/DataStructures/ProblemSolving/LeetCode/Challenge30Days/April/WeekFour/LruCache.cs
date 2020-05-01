using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekFour
{
    // Challenge 24: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/531/week-4/3309/
    // Implement LRU Cache

    // References
    // https://www.youtube.com/watch?v=S6IfqDXWa10
    // https://github.com/bephrem1/backtobackswe/blob/master/Linked%20Lists/LRUCache/LRUCache.java

    public class LruCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, ListNode> _dictionary = new Dictionary<int, ListNode>();
        private readonly ListNode _head = new ListNode() {Name = "Head"};
        private readonly ListNode _tail = new ListNode() {Name = "Tail"};
        private int _currentNoOfElements;

        //Backing up dictionary with Double linked list
        //dictionary for faster lookup and Double linked list for faster add and removals

        public LruCache(int capacity)
        {
            _capacity = capacity;

            _currentNoOfElements = 0;
            _head.Next = _tail;
            _tail.Previous = _head;
        }

        public static void Init()
        {
            var cache = new LruCache(2);
            cache.Put(2, 1);
            cache.Put(2, 2);
            var get1 = cache.Get(2);
            cache.Put(1, 1);
            cache.Put(4, 1);
            var get3 = cache.Get(2);
        }

        public int Get(int key)
        {
            if (_dictionary.ContainsKey(key))
            {
                // if key exists, return the value associated
                // along with, as this key is accessed, it is moved to the
                // front of the list
                var existingNode = _dictionary[key];

                //As accessed move to front
                RemoveNode(existingNode);
                AddElementAfterHead(existingNode);

                //returning the actual value
                return existingNode.Value;
            }

            //If key does not exist, return -1
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_dictionary.ContainsKey(key))
            {
                // if key exists, then update the value in dictionary
                // as this value is accessed, we have to move this to starting of the list
                // remove and add the node with updated value to the front of the list.
                var existingNode = _dictionary[key];
                //As accessed, move it to the front
                RemoveNode(existingNode);

                existingNode.Value = value;
                AddElementAfterHead(existingNode);
                _dictionary[key] = existingNode;
            }
            else
            {
                //As key does not exist, add a new node at the front of the list
                var newNode = new ListNode()
                {
                    Key = key,
                    Value = value
                };

                _dictionary.Add(key, newNode);
                AddElementAfterHead(newNode);
                _currentNoOfElements++;

                //Check if current capacity exceeds the capacity of the list
                if (_currentNoOfElements > _capacity)
                {
                    //Capacity increased, remove the last element (Least recently used)
                    RemoveElementBeforeTail();
                }
            }
        }

        // This code removes the node just before the Tail in the list
        // Remove the same from dictionary to maintain the uniformity of data
        // Decrease currentCapacity
        private void RemoveElementBeforeTail()
        {
            var nodeToBeRemoved = _tail.Previous;
            var prevNode = nodeToBeRemoved.Previous;

            prevNode.Next = _tail;
            _tail.Previous = prevNode;

            _dictionary.Remove(nodeToBeRemoved.Key);
            _currentNoOfElements--;
        }

        // This code just adds a new node in the start of the list 
        // just after the dummy head
        private void AddElementAfterHead(ListNode node)
        {
            var headsNext = _head.Next;
            _head.Next = node;
            node.Next = headsNext;
            headsNext.Previous = node;
            node.Previous = _head;
        }

        // This code will unlink the node from the linked list
        private void RemoveNode(ListNode node)
        {
            var prevNode = node.Previous;
            var nextNode = node.Next;

            prevNode.Next = nextNode;
            nextNode.Previous = prevNode;
        }
    }

    public class ListNode
    {
        public int Key { get; set; }

        public int Value { get; set; }

        public string Name { get; set; }

        public ListNode Next { get; set; }

        public ListNode Previous { get; set; }
    }
}