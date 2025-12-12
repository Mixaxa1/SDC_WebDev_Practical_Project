using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.TodoList;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.Controllers;
public class TodoListController : Controller
{
    private readonly ITodoListApiService _todoListApiService;

    public TodoListController(ITodoListApiService todoListApiService)
    {
        _todoListApiService = todoListApiService;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var lists = await _todoListApiService.GetAllAsync();

        return View(lists);
    }

    public async Task<IActionResult> Details(Guid id)
    {
         var list = await _todoListApiService.GetByIdAsync(id, true);

        return View(list);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var list = await _todoListApiService.GetByIdAsync(id);

        if (list == null)
        {
            return NotFound();
        }

        var listView = new TodoListModel
        {
            Id = id,
            Title = list.Title,
            Description = list.Description,
        };

        return View(listView);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(Guid id)
    {
        await _todoListApiService.DeleteAsync(id);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var list = await _todoListApiService.GetByIdAsync(id);

        var editList = new CreateTodoListModel
        {
            Id = list.Id,
            Title = list.Title,
            Description = list.Description
        };

        return View(editList);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CreateTodoListModel vm)
    {
        var result = await _todoListApiService.UpdateAsync(vm);

        return RedirectToAction("Details", new { id = result.Id });
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoListModel vm)
    {
        var result = await _todoListApiService.CreateAsync(vm);

        return RedirectToAction("Details", new { id = result.Id });
    }
}
