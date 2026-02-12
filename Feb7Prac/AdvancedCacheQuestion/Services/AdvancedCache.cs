using System;
using System.Collections.Generic;
using Q08_AdvancedCache.Models;

namespace Q08_AdvancedCache.Services
{
    public class AdvancedCache<TKey, TValue>
    {
        private readonly int _capacity;
        private readonly Dictionary<TKey, LinkedListNode<TKey>> _map = new();
        private readonly Dictionary<TKey, CacheItem<TValue>> _cache = new();
        private readonly LinkedList<TKey> _lruList = new();
        private readonly object _lock = new();

        public AdvancedCache(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be positive");

            _capacity = capacity;
        }

        public void Set(TKey key, TValue value, int ttlSeconds)
        {
            lock (_lock)
            {
                RemoveIfExpired(key);

                if (_cache.ContainsKey(key))
                {
                    MoveToRecent(key);
                    _cache[key] = CreateItem(value, ttlSeconds);
                    return;
                }

                if (_cache.Count >= _capacity)
                {
                    EvictLeastRecentlyUsed();
                }

                var node = new LinkedListNode<TKey>(key);
                _lruList.AddLast(node);
                _map[key] = node;
                _cache[key] = CreateItem(value, ttlSeconds);
            }
        }

        public TValue? Get(TKey key)
        {
            lock (_lock)
            {
                RemoveIfExpired(key);

                if (!_cache.ContainsKey(key))
                    return default;

                MoveToRecent(key);
                return _cache[key].Value;
            }
        }

        private void MoveToRecent(TKey key)
        {
            var node = _map[key];
            _lruList.Remove(node);
            _lruList.AddLast(node);
        }

        private void EvictLeastRecentlyUsed()
        {
            var lruKey = _lruList.First!.Value;
            _lruList.RemoveFirst();
            _map.Remove(lruKey);
            _cache.Remove(lruKey);
        }

        private void RemoveIfExpired(TKey key)
        {
            if (_cache.ContainsKey(key) && _cache[key].IsExpired)
            {
                _lruList.Remove(_map[key]);
                _map.Remove(key);
                _cache.Remove(key);
            }
        }

        private CacheItem<TValue> CreateItem(TValue value, int ttlSeconds)
        {
            return new CacheItem<TValue>(
                value,
                DateTime.UtcNow.AddSeconds(ttlSeconds));
        }
    }
}
