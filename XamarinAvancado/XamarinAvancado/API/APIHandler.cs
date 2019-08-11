using Newtonsoft.Json;
using XamarinAvancado.Models;
using System.Net.Http;
using System.Diagnostics;

namespace XamarinAvancado.API
{
    public class APIHandler
    {
        public RootObject GetData(string cityName)
        {
            HttpClient client = new HttpClient();
            var vals = client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={cityName}&APPID=cb57c2177a8ebeddcfbd91ed48ae140b").Result;
            var result = vals.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(result.ToString());
            var seriliaze = JsonConvert.DeserializeObject<RootObject>(result);
            return seriliaze;
        }
    }

    public interface IAPIHandler
    {
        RootObject GetData(string cityName);
    }
}
