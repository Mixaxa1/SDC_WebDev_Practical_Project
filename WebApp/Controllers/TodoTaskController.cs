using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApp.Models.TodoList;
using WebApp.Models.TodoTask;
using WebApp.WebApiServices;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.Controllers
{
    public class TodoTaskController : Controller
    {
        private readonly ITodoTaskApiService _todoTaskApiService;

        public TodoTaskController(ITodoTaskApiService todoTaskApiService)
        {
            _todoTaskApiService = todoTaskApiService;
        }

        // GET: TodoTaskController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TodoTaskController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var task = await _todoTaskApiService.GetByIdAsync(id);

            return View(task);
        }

        // GET: TodoTaskController/Create
        public IActionResult Create(int id)
        {
            var task = new CreateTodoTask
            {
                ListId = id
            };

            return View(task);
        }

        // POST: TodoTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTodoTask vm)
        {
            var task = new TodoTaskModel
            {
                ListId = vm.ListId,
                Title = vm.Title,
                Description = vm.Description,
                DueAt = vm.DueAt
            };

            await _todoTaskApiService.CreateAsync(task);

            return RedirectToAction("Details", "TodoList", new {id = vm.ListId});
        }

        // GET: TodoTaskController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _todoTaskApiService.GetByIdAsync(id);

            return RedirectToAction("");
        }

        // POST: TodoTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoTaskController/Delete/5
        public async Task<IActionResult> Delete(int id, int listId)
        {
            await _todoTaskApiService.DeleteAsync(id);

            return RedirectToAction("Details", "TodoList", listId);
        }

        // POST: TodoTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
