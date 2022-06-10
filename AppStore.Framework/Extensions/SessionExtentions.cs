using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace AppStore.Framework.Extentions
{
    public static class SessionExtentions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            var options =
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
            session.SetString(key, JsonSerializer.Serialize(value: value, options: options));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            
            var jsonObject = session.GetString(key);
            if (string.IsNullOrEmpty(jsonObject))
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(json: jsonObject);
        }
    }
}
