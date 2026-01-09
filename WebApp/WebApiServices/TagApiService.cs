using System.Web;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Models.TaskTag;
using WebApp.Models.TodoList;
using WebApp.Models.TodoTask;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices
{
    public class TagApiService : ApiService, ITagApiService
    {
        public TagApiService(IOptions<EndpointsOptions> options) : base(options)
        {
            _baseRoute = options.Value.CommonBase + options.Value.TagEndpoints.Base;
        }

        public async Task<TagModel> CreateAsync(TagModel postObject)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync(new Uri(_baseRoute), postObject);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TagModel>(content);

            return result;
        }

        public async Task<List<TagModel>> GetAllAsync()
        {
            List<TagModel> result = [];

            using var client = new HttpClient();

            var response = await client.GetAsync(new Uri(_baseRoute));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<List<TagModel>>(content);

            return result;
        }

        public async Task<TagModel> GetByIdAsync(Guid id)
        {
            TagModel result = null;
            using (var client = new HttpClient())
            {
                var builder = new UriBuilder(_baseRoute + id.ToString());

                var query = HttpUtility.ParseQueryString(string.Empty);
                builder.Query = query.ToString();

                var response = await client.GetAsync(builder.ToString());

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TagModel>(content);
            }

            return result;
        }
    }
}
