using Newtonsoft.Json;
using System.Net;

namespace WeatherAPI.Model;

public class WeatherHandler
{
    private static readonly HttpClient client = new HttpClient()
    {
        BaseAddress = new Uri("http://api.weatherapi.com")
    };

    public GetWeatherModel GetWeather()
    {
        var response = client.GetAsync("/v1/current.json?Key=5610de1f38b141c4bc861751243009&q=shiraz").Result;
        if(response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        var content = response.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<GetWeatherModel>(content);

        return result;
    }
}
