﻿using DevExpress.Web.ASPxClasses.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace ERestaurant.Util
{
    public class UploadingUtils
    {
        public static void RemoveFileWithDelay(string key, string fullPath, int delay)
        {
            if (HttpUtils.GetCache()[key] == null)
            {
                DateTime absoluteExpiration = DateTime.Now.Add(new TimeSpan(0, delay, 0));
                HttpUtils.GetCache().Insert(key, fullPath, null, absoluteExpiration,
                    Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(RemovedCallback));
            }
        }
        public static void RemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            if (File.Exists(value.ToString()))
                File.Delete(value.ToString());
        }
    }
}