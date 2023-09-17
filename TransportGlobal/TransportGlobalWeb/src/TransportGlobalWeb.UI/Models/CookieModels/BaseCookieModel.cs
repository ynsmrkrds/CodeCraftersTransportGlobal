using Newtonsoft.Json;

namespace TransportGlobalWeb.UI.Models.CookieModels
{
    public abstract class BaseCookieModel
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static T? FromJson<T>(string json) where T : BaseCookieModel
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
