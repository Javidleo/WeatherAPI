using Newtonsoft.Json;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

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
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return "error";
        }

        var content = response.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<List<GetAllTaskVm>>(content);

        var serializedContent = JsonConvert.SerializeObject(result);

        return content;
    }
    public bool CreateTask(CreateTaskDto dto)
    {
        var response = client.PostAsJsonAsync("api/ToDo", dto).Result;
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            return false;
        }

        return true;
    }
    public bool Unmark(int id)
    {
        var response = client.PatchAsJsonAsync($"api/ToDo/unmark/{id}",new object()).Result; 
        if(response.StatusCode != HttpStatusCode.NoContent)
        {
            return false;
        }

        return true;
    }
    public bool Mark(int id)
    {
        var response = client.PatchAsJsonAsync($"api/ToDo/mark/{id}", new object()).Result;
        if(response.StatusCode != HttpStatusCode.NoContent)
        {
            return false;
        }
        return true;
    }
}
