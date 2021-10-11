using Microsoft.AspNetCore.Http;

using E_commerceFirstFull.Models;

using System.Text.Json;

namespace E_commerceFirstFull
{
    public static class SessionExtension
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize<T>(value));
        }

        public static T Get<T>(this ISession session, string key, out T outerValue)
        {
            var sessionValue = session.GetString(key);
            return sessionValue == null ? outerValue = default(T) : outerValue = JsonSerializer.Deserialize<T>(sessionValue);
        }
    }
}
