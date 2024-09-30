using Newtonsoft.Json;
using System.Net;

namespace WeatherAPI.Model;

public class ToDoListHandler
{
    private static readonly HttpClient client = new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:7057")
    };

    public string GetAllTasks()
    {
        var response = client.GetAsync("api/ToDo").Result;
        if(response.StatusCode != HttpStatusCode.OK)
        {
            return "";
        }

        var content = response.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<List<GetAllTaskVm>>(content);
        
        return content;
    }
}
