using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
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

    public async Task<IActionResult> Details(int id)
    {
        var list = await _todoListApiService.GetByIdAsync(id);

        return View(list);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _todoListApiService.DeleteAsync(id);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var list = await _todoListApiService.GetByIdAsync(id);

        var editList = new EditTodoList
        {
            Id = list.Id,
            Title = list.Title,
            Description = list.Description
        };

        return View(editList);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromRoute] int id, EditTodoList vm)
    {
        var list = new TodoList
        {
            Id = vm.Id,
            Title = vm.Title,
            Description = vm.Description
        };

        await _todoListApiService.UpdateAsync(id, list);

        return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoList vm)
    {
        var list = new TodoList
        {
            Title = vm.Title,
            Description = vm.Description
        };

        await _todoListApiService.CreateAsync(list);

        return RedirectToAction("Index");
    }
}
