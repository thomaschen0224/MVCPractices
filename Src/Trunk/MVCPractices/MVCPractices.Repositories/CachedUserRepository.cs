using System;
using System.Runtime.Caching;
using MVCPractices.Models;

namespace MVCPractices.Repositories
{
    public class CachedUserRepository:UserRepository
    {
        public override CurrentUser GetCurrentUser(string guid)
        {

            var key = guid;
            var cache = MemoryCache.Default;

            if (!(cache[guid] is CurrentUser user))
            {
                user = base.GetCurrentUser(guid);
                CacheItem item = new CacheItem(key, user);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(1);
                cache.Set(item, policy);
            }

            return user;

        }
    }
}