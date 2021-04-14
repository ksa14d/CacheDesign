using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDesign
{
    class Cache<K, V> : ICache<K, V>
    {     
        protected Dictionary<K, CacheItem<K,V>> _cache;     

        public Cache()
        {           
            _cache = new Dictionary<K, CacheItem<K, V>>();           
        }

        protected virtual CacheItem<K, V> CreateItem(K key, V value) // creational pattern
        {
            var item = new CacheItem<K, V>(key, value);
            return item;
        }

        protected string PrintCache()
        {
            string cacheContents = string.Join(" ", _cache.Keys);
            return cacheContents;
        }

        protected CacheItem<K,V> Insert(K key, V value)
        {
            CacheItem<K, V> item;
            if (_cache.ContainsKey(key)) //update an existing key 
            {
                item = _cache[key];
                item.Value = value;
            }
            else // new key
            {
                item = CreateItem(key, value);
                _cache.Add(key, item);
            }
            return item;
        }

        protected CacheItem<K, V> Lookup(K key)
        {
            if (_cache.ContainsKey(key))
            {
                return _cache[key];               
            }
            return null;
        }

        public virtual void Add(K key, V value)
        {
            Insert(key, value);
        }
       
        public virtual V Get(K key) // gets the item if it exists other wise returns a default value
        {
            var item = Lookup(key);
            if (item == null) return default;
            return item.Value;
        }
    }
}
