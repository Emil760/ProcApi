﻿namespace ProcApi.Caches
{
    public static class CacheKeys
    {
        public const string BASE_USER_KEY = "user";

        public static string GetUserKey(object id)
        {
            return BASE_USER_KEY + "_" + id;
        }
    }
}
