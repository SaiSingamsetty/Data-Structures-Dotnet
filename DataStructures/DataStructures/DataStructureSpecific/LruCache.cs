using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific
{
    //https://leetcode.com/problems/lru-cache/

    //References
    // https://medium.com/@bommuchetan/lru-cache-implementation-in-java-97d04bc5fe83
    // https://krishankantsinghal.medium.com/my-first-blog-on-medium-583159139237

    public class LruCacheTest
    {
        public void TestCache()
        {
            var cache = new LruCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            cache.Get(2);       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            cache.Get(1);       // returns -1 (not found)
            cache.Get(3);       // returns 3
            cache.Get(4);       // returns 4
        }
    }

    public class LruCache
    {
        private readonly Dictionary<int, ListNode> _lruLookUp;

        private ListNode _head;

        private ListNode _tail;

        private readonly int _lruMaxSize;

        public LruCache(int size = 4)
        {
            _lruMaxSize = size;
            _lruLookUp = new Dictionary<int, ListNode>();
        }

        public int Get(int key)
        {
            if (_lruLookUp.ContainsKey(key))
            {
                /*
                 * Get ListNode details from Lookup
                 * Remove that entry in cache
                 * Add as a fresh entry in cache
                 */
                var nodeValue = _lruLookUp[key];
                RemoveFromCache(nodeValue);
                AddToCache(nodeValue);
                return nodeValue.Value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (_lruLookUp.ContainsKey(key))
            {
                //Update and move to top of cache
                var nodeValue = _lruLookUp[key];
                nodeValue.Value = value;
                RemoveFromCache(nodeValue);
                AddToCache(nodeValue);

                //update look up as well
                _lruLookUp[key] = nodeValue;
            }
            else
            {
                //Add to look up and add to cache
                var newNode = new ListNode {Value = value, Key = key};

                //Check if cache size exceeded
                if (_lruLookUp.Count >= _lruMaxSize)
                {
                    //Max reached
                    //So remove Tail end value in cache
                    _lruLookUp.Remove(_tail.Key);
                    RemoveFromCache(_tail);
                    AddToCache(newNode);
                }
                else
                {
                    AddToCache(newNode);
                }

                //Add to look up as well
                _lruLookUp.Add(key, newNode);
            }
        }

        private void AddToCache(ListNode node)
        {
            node.Next = _head;
            if (_head != null)
            {
                _head.Prev = node;
            }

            _head = node;
            if (_tail == null)
                _tail = _head;
        }

        private void RemoveFromCache(ListNode node)
        {
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                _head = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                _tail = node.Prev;
            }
        }

    }

    public class ListNode
    {
        public int Value { get; set; }

        public int Key { get; set; }

        public ListNode Next { get; set; }

        public ListNode Prev { get; set; } 
    }
}
