namespace ProcApi.Application.Caches;

public static class CacheKeys
{
    public const string BASE_USER_KEY = "user";
    public const string CONNECTED_USERS = "connected_users";

    public static string GetUserKey(object id)
    {
        return BASE_USER_KEY + "_" + id;
    }
}