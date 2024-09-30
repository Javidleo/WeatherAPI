using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllTask()
    {
        var toDoListHandler = new ToDoListHandler();

        var content = toDoListHandler.GetAllTasks();
        return Ok(content); 
    }
}
