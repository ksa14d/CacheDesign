using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDesign
{
    public class CacheItem<K,V> 
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public CacheItem(K key, V value)
        {
            Key = key;
            Value = value;            
        }
    }
}
