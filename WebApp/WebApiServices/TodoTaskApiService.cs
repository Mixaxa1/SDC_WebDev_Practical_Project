using System.Web;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Models.TodoList;
using WebApp.Models.TodoTask;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices
{
    public class TodoTaskApiService : ApiService, ITodoTaskApiService
    {
        public TodoTaskApiService(IOptions<EndpointsOptions> options) : base(options)
        {
            _baseRoute = options.Value.CommonBase + options.Value.TaskEndpoints.Base;
        }

        public async Task<TodoTaskModel> CreateAsync(CreateTodoTaskModel postObject)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync(new Uri(_baseRoute), postObject);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TodoTaskModel>(content);

            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync(new Uri(_baseRoute + $"{id}"));

            response.EnsureSuccessStatusCode();
        }

        public async Task<List<TodoTaskModel>> GetAllAsync()
        {
            List<TodoTaskModel> result = [];

            using var client = new HttpClient();

            var response = await client.GetAsync(new Uri(_baseRoute));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<List<TodoTaskModel>>(content);

            return result;
        }

        public async Task<TodoTaskModel> GetByIdAsync(Guid id, bool withIncludes = false)
        {
            TodoTaskModel result = null;
            using (var client = new HttpClient())
            {
                var builder = new UriBuilder(_baseRoute + id.ToString());

                var query = HttpUtility.ParseQueryString(string.Empty);
                query["withIncludes"] = withIncludes.ToString();
                builder.Query = query.ToString();

                var response = await client.GetAsync(builder.ToString());

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TodoTaskModel>(content);
            }

            return result;
        }

        public async Task<TodoTaskModel> UpdateAsync(CreateTodoTaskModel model)
        {
            TodoTaskModel result = null;
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync(new Uri(_baseRoute), model);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TodoTaskModel>(content);
            }

            return result;
        }
    }
}
