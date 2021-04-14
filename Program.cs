using System;

namespace CacheDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache<int,int> cache = new LRUCache<int,int>(2);
            int x = -1;
            cache.Add(1, 10); // it will save a key (1) with value 10 in the cache. 
            cache.Add(2, 20); // it will save a key (2) with value 20 in the cache. 
            x = cache.Get(1); // returns 10 
            cache.Add(3, 30); // evicts key 2 and save a key (3) with value 30 in the cache. 
            x = cache.Get(2); // returns 0 (not found) 
            cache.Add(4, 40); // evicts key 1 and save a key (4) with value 40 in the cache. 
            x = cache.Get(1); // returns 0 (not found) 
            x= cache.Get(3); // returns 30 
            x= cache.Get(4); // returns 40
        }
    }
}
