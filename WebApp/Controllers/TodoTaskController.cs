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
        public async Task<IActionResult> Details(Guid id)
        {
            var task = await _todoTaskApiService.GetByIdAsync(id);

            return View(task);
        }

        // GET: TodoTaskController/Create
        public IActionResult Create(Guid id)
        {
            var task = new CreateTodoTaskModel
            {
                ListId = id
            };

            return View(task);
        }

        // POST: TodoTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTodoTaskModel vm)
        {
            var result = await _todoTaskApiService.CreateAsync(vm);

            return RedirectToAction("Details", result);
        }

        // GET: TodoTaskController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            /*var task = await _todoTaskApiService.GetByIdAsync(id);

            var editTask = new TodoTaskModel
            {
                Id = task.Id,
                ListId = task.ListId,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DueAt = task.DueAt,
                Status = task.Status
            };

            return View(editTask);*/

            return View(Details(id));
        }

        // POST: TodoTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, IFormCollection collection)
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
        public async Task<IActionResult> Delete(Guid id, int listId)
        {
            await _todoTaskApiService.DeleteAsync(id);

            return RedirectToAction("Details", "TodoList", listId);
        }

        // POST: TodoTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, IFormCollection collection)
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
