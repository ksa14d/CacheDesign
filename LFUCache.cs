using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDesign
{
    class LFUCache<K, V> : Cache<K, V> 
    {
        private readonly int _capacity;        
        private readonly PriorityQueue<LFUCacheItem<K, V>> _queue;

        public LFUCache(int Capacity) : base()
        {
            _capacity = Capacity;            
            _queue = new PriorityQueue<LFUCacheItem<K, V>>();
        }

        protected override LFUCacheItem<K, V> CreateItem(K key, V value)
        {
            var item = new LFUCacheItem<K, V>(key, value);
            return item;
        }
      

        public override void Add(K key, V value)
        {
            bool isExistingKey = _cache.ContainsKey(key);
            if (!isExistingKey && _cache.Count == _capacity) // new item to add and capacity reached
            {
                EvictLeastFrequentItem(); // make space by eviction 
                isExistingKey = false;
            }
            var item = Insert(key, value) as LFUCacheItem<K,V>;
            if (isExistingKey) item.Frequency++;
            else _queue.Enqueue(item);
        }

        private void EvictLeastFrequentItem()
        {
            var item = _queue.Dequeue();
            _cache.Remove(item.Key); 
        }

        public override V Get(K key)
        {
            var item = Lookup(key) as LFUCacheItem<K, V>;
            if (item != null)
            {
                item.Frequency++;
                return item.Value;
            }
            return default;            
        }
    }
}
