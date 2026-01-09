using Microsoft.AspNetCore.Mvc;
using WebApp.Models.TaskTag;
using WebApp.Models.TodoList;
using WebApp.ViewModels;
using WebApp.WebApiServices;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagApiService _tagApiService;

        public TagController(ITagApiService tagApiService)
        {
            _tagApiService = tagApiService;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var tags = await _tagApiService.GetAllAsync();

            return View(tags);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var tag = await _tagApiService.GetByIdAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            var tagView = new TagModel
            {
                Id = id,
                Title = tag.Title
            };

            return View(tagView);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            await _tagApiService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagModel vm)
        {
            var result = await _tagApiService.CreateAsync(vm);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddTag([FromBody] SelectedTagViewModel tag)
        {
            return PartialView("_SelectedTag", tag);
        }
    }
}
