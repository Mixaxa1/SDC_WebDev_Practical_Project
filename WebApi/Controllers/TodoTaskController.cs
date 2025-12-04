using Database;
using Database.EntityServices.Interfaces;
using Domain.Entities.List;
using Domain.Entities.Task;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoTaskController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ITodoListDbService _listDbService;
    private readonly ITodoTaskDbService _taskDbService;

    public TodoTaskController(AppDbContext context, ITodoListDbService todoListDbService, ITodoTaskDbService todoTaskDbService)
    {
        _context = context;
        _listDbService = todoListDbService;
        _taskDbService = todoTaskDbService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(TodoTaskModel taskModel)
    {
        var parentList = await _listDbService.GetByIdAsync(taskModel.ListId);

        var newTask = new TodoTask()
        {
            List = parentList,
            Title = taskModel.Title,
            Description = taskModel.Description,
            CreatedAt = DateTime.Now,
            DueAt = DateTime.Now,
            Status = TaskState.NotStarted
        };

        await _taskDbService.CreateAsync(newTask);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoTaskModel>> GetById(int id)
    {
        var task = await _taskDbService.GetByIdAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        var taskModel = new TodoTaskModel()
        {
            Id = task.Id,
            ListId = task.List.Id,
            Title = task.Title,
            Description = task.Description,
            CreatedAt = task.CreatedAt,
            DueAt= task.DueAt,
            Status = (int)task.Status,

        };

        return taskModel;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTaskModel>>> GetAll()
    {
        var tasks = await _taskDbService.GetAllAsync();
        var modelTasks = new List<TodoTaskModel>();

        foreach (var task in tasks)
        {
            modelTasks.Add(new TodoTaskModel()
            {
                Id = task.Id,
                ListId= task.List.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DueAt= task.DueAt,
                Status = (int)task.Status,
            });
        }

        return modelTasks;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TodoTaskModel taskModel)
    {
        if (id != taskModel.Id)
        {
            return BadRequest();
        }

        var task = await _taskDbService.GetByIdAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        task.Title = task.Title;
        task.Description = task.Description;

        _taskDbService.Update(task);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _taskDbService.GetByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _taskDbService.Delete(task);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
