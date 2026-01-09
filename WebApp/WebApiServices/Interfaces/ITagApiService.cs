using WebApp.Models.TaskTag;
using WebApp.Models.TodoTask;

namespace WebApp.WebApiServices.Interfaces
{
    public interface ITagApiService
    {
        public Task<TagModel> CreateAsync(TagModel postObject);

        public Task DeleteAsync(Guid id);

        public Task<List<TagModel>> GetAllAsync();

        public Task<TagModel> GetByIdAsync(Guid id);
    }
}
