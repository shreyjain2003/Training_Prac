using System;

namespace Q08_AdvancedCache.Models
{
    public class CacheItem<TValue>
    {
        public TValue Value { get; }
        public DateTime ExpiryTime { get; }

        public CacheItem(TValue value, DateTime expiryTime)
        {
            Value = value;
            ExpiryTime = expiryTime;
        }

        public bool IsExpired => DateTime.UtcNow > ExpiryTime;
    }
}
