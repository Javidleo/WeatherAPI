using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ToDoListHandler _handler;
    public TestController(ToDoListHandler handler)
    {
        _handler = handler;
    }
    [HttpGet]
    public IActionResult GetAllTask()
    {
        var toDoListHandler = new ToDoListHandler();

        var content = toDoListHandler.GetAllTasks();
        return Ok(content); 
    }
    
    [HttpGet("weather")]
    public IActionResult GetWeather()
    {
        var weatherHandler = new WeatherHandler();

        var content = weatherHandler.GetWeather();
        return Ok(content);
    }

    [HttpPost]
    public IActionResult CreateTasks([FromBody] CreateTaskDto dto)
    {
        bool success = _handler.CreateTask(dto);

        if(success == true)
        {
            return Ok("created successfully");
        }
        else
        {
            return BadRequest("failed to create task");
        }
    }

    [HttpPatch("unmark/{id}")]
    public IActionResult UncheckStatus(int id)
    {
        var task = _handler.Unmark(id);

        if(task == true)
        {
            return Ok("Updated successfully");
        }
        else
        {
            return NotFound("not found");
        }
    }
    
    [HttpPatch("mark/{id}")]
    public IActionResult CheckStatus(int id)
    {
        var task = _handler.Mark(id);

        if(task == true)
        {
            return Ok("Checked");
        }
        else
        {
            return BadRequest("Already checked");
        }
    }
}
