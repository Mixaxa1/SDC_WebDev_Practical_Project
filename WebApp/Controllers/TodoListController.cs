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

    public async Task Delete(int id)
    {
        await _todoListApiService.DeleteAsync(id);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var list = await _todoListApiService.GetByIdAsync(id);

        return View(list);
    }
}
