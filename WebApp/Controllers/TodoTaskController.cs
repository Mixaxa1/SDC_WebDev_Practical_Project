using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApp.Models.TaskTag;
using WebApp.Models.TodoList;
using WebApp.Models.TodoTask;
using WebApp.ViewModels;
using WebApp.WebApiServices;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.Controllers
{
    public class TodoTaskController : Controller
    {
        private readonly ITodoTaskApiService _todoTaskApiService;
        private readonly ITagApiService _taskTagApiService;

        public TodoTaskController(ITodoTaskApiService todoTaskApiService, ITagApiService taskTagApiService)
        {
            _todoTaskApiService = todoTaskApiService;
            _taskTagApiService = taskTagApiService;
        }

        // GET: TodoTaskController
        public ActionResult Index()
        {
            return View();

        }

        // GET: TodoTaskController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var task = await _todoTaskApiService.GetByIdAsync(id, true);

            return View(task);
        }

        // GET: TodoTaskController/Create
        public async Task<IActionResult> Create(Guid id)
        {
            var avalableTags = await _taskTagApiService.GetAllAsync();
            var task = new CreateTodoTaskViewModel
            {
                ListId = id,
                TagSelectionOptions = avalableTags
            };

            return View(task);
        }

        // POST: TodoTaskController/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoTaskViewModel vm)
        {
            var taskModel = new CreateTodoTaskModel
            {
                Id = vm.Id,
                ListId = vm.ListId,
                Title = vm.Title,
                Description = vm.Description,
                DueAt = vm.DueAt,
                Status = vm.Status,
                Tags = vm.SelectedTags
            };

            var result = await _todoTaskApiService.CreateAsync(taskModel);

            return RedirectToAction("Details", new { id = result.Id });
        }

        // GET: TodoTaskController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var avalableTags = await _taskTagApiService.GetAllAsync();
            var task = await _todoTaskApiService.GetByIdAsync(id, true);

            var editTask = new CreateTodoTaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueAt = task.DueAt,
                Status = task.Status,
                SelectedTags = new List<TagModel>(),
                TagSelectionOptions = avalableTags
            };

            foreach (var tag in task.Tags)
            {
                editTask.SelectedTags.Add(new TagModel()
                {
                    Id = tag.Id,
                    Title = tag.Title
                });
            }

            return View(editTask);
        }

        // POST: TodoTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateTodoTaskViewModel vm)
        {
            var taskModel = new CreateTodoTaskModel
            {
                Id = vm.Id,
                ListId = vm.ListId,
                Title = vm.Title,
                Description = vm.Description,
                DueAt = vm.DueAt,
                Status = vm.Status,
                Tags = vm.SelectedTags
            };

            var result = await _todoTaskApiService.UpdateAsync(taskModel);

            return RedirectToAction("Details", new { id = result.Id });
        }

        // GET: TodoTaskController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _todoTaskApiService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            var listView = new TodoTaskModel
            {
                Id = task.Id,
                ListId = task.ListId,
                Title = task.Title,
                Description = task.Description
            };

            return View(listView);
        }

        // POST: TodoTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid id, Guid listId)
        {
            await _todoTaskApiService.DeleteAsync(id);

            return RedirectToAction("Details", "TodoList", new { id = listId });
        }
    }
}
