using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDesign
{
    class LRUCache<K, V> : Cache<K, V> , ICache<K,V>
    {
        private readonly int _capacity;        
        private readonly LinkedList<CacheItem<K, V>> _queue; // doubly linked list in C#

        public LRUCache(int Capacity) : base()
        {
            _capacity = Capacity;            
            _queue = new LinkedList<CacheItem<K, V>>();
        }

        protected override LRUCacheItem<K, V> CreateItem(K key, V value)
        {
            var item = new LRUCacheItem<K, V>(key, value);
            return item;
        }

        public override void Add(K key, V value)
        {
            bool isExistingKey = _cache.ContainsKey(key);
            if (!isExistingKey && _cache.Count == _capacity) // new item to add and capacity reached
            {
                EvictLeastRecentlyUsedItem(); // make space by eviction 
                isExistingKey = false;
            }

            var item = Insert(key, value) as LRUCacheItem<K, V>;
            if (isExistingKey) RefreshQueue(item.Node);
            else _queue.AddFirst(item.Node);
        }

        private void RefreshQueue(LinkedListNode<CacheItem<K, V>> node)
        {
            _queue.Remove(node);
            _queue.AddFirst(node);
        }

        private void EvictLeastRecentlyUsedItem() // least  recent items are at the end of the queue
        {
            var item = _queue.Last.Value;
            _queue.RemoveLast();
            _cache.Remove(item.Key); 
        }

        private string PrintLRUQueue()
        {
            string[] queueContents = _queue.Select(item => item.Key + " " + item.Value).ToArray();
            return string.Join(" \n", queueContents);
        }

        public override V Get(K key)
        {
            var item = Lookup(key) as LRUCacheItem<K, V>;
            if (item != null)
            {
                RefreshQueue(item.Node);
                return item.Value;
            }
            return default;
        }
    }
}
