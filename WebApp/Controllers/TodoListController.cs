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
         var list = await _todoListApiService.GetByIdWithTasksAsync(id);

        return View(list);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        await _todoListApiService.DeleteAsync(id);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var list = await _todoListApiService.GetByIdAsync(id);

        var editList = new TodoListModel
        {
            Id = list.Id,
            Title = list.Title,
            Description = list.Description
        };

        return View(editList);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TodoListModel vm)
    {
        var list = new TodoListModel
        {
            Id = vm.Id,
            Title = vm.Title,
            Description = vm.Description
        };

        await _todoListApiService.UpdateAsync(list);

        return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoList vm)
    {
        var list = new TodoListModel
        {
            Title = vm.Title,
            Description = vm.Description
        };

        await _todoListApiService.CreateAsync(list);

        return RedirectToAction("Index");
    }
}
