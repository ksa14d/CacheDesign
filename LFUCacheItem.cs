using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDesign
{
    public class LFUCacheItem<K,V> : CacheItem<K,V> , IComparable<LFUCacheItem<K, V>> 
    {
        public int Frequency { get; set; }

        public LFUCacheItem(K key, V value) : base(key, value)
        {          
            Frequency = 1;
        }
        public virtual int CompareTo(LFUCacheItem<K, V> other)
        {
            return other.Frequency.CompareTo(this.Frequency); // change 
        }
    }



}
