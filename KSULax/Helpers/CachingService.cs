using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace KSULax.Helpers
{
    public class CachingService
    {
        protected Cache Cache { get; set; }

        public int CacheDurationMinutes { get; set; }

        public CachingService()
        {
            Cache = HttpRuntime.Cache;
            CacheDurationMinutes = 60;
        }

        public virtual object Get(string keyname)
        {
            return Cache.Get(keyname);
        }

        public virtual T Get<T>(string keyname)
        {
            object o = Cache.Get(keyname);
            if (null != o)
            {
                return (T)o;
            }
            else
            {
                return default(T);
            }
        }

        public virtual void Insert(string keyname, object item)
        {
            Cache.Insert(keyname, item, null, DateTime.UtcNow.AddMinutes(CacheDurationMinutes), Cache.NoSlidingExpiration);
        }

        public virtual void Insert(string keyname, object item, CacheDependency dependency)
        {
            Cache.Insert(keyname, item, dependency);
        }

        public virtual void Remove(string keyname)
        {
            Cache.Remove(keyname);
        }
    }
}