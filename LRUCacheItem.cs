using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDesign
{
    public class LRUCacheItem<K,V> : CacheItem<K,V> 
    {
        public LinkedListNode<CacheItem<K, V>> Node { get; set; }

        public LRUCacheItem(K key, V value) : base(key, value)
        {
            Node = new LinkedListNode<CacheItem<K, V>>(this);
        }       
    }



}
