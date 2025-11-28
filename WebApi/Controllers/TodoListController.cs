using Database;
using Database.EntityServices.Interfaces;
using Domain.Entities.List;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ITodoListDbService _dbService;

    public TodoListController(AppDbContext context, ITodoListDbService todoListDbService)
    {
        _context = context;
        _dbService = todoListDbService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(TodoListModel listModel)
    {
        var newList = new TodoList()
        {
            Title = listModel.Title,
            Description = listModel.Description,
        };

        await _dbService.CreateAsync(newList);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoListModel>> GetById(int id)
    {
        var list = await _dbService.GetByIdAsync(id);

        if (list == null)
        {
            return NotFound();
        }

        var listModel = new TodoListModel()
        {
            Id = list.Id,
            Title = list.Title,
            Description = list.Description,
        };

        return listModel;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoListModel>>> GetAll()
    {
        var lists = await _dbService.GetAllAsync();
        var modelLists = new List<TodoListModel>();

        foreach (var list in lists)
        {
            modelLists.Add(new TodoListModel()
            {
                Id = list.Id,
                Title = list.Title,
                Description = list.Description,
            });
        }

        return modelLists;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TodoListModel listModel)
    {
        if (id != listModel.Id)
        {
            return BadRequest();
        }

        var listFromDb = await _dbService.GetByIdAsync(id);

        if (listFromDb == null)
        {
            return NotFound();
        }

        listFromDb.Title = listModel.Title;
        listFromDb.Description = listModel.Description;

        _dbService.Update(listFromDb);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var list = await _dbService.GetByIdAsync(id);
        if (list == null)
        {
            return NotFound();
        }

        _dbService.Delete(list);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
