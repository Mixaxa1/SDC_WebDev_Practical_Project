using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Models.TodoTask;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices
{
    public class TodoTaskApiService : ApiService<TodoTaskModel>, ITodoTaskApiService
    {
        public TodoTaskApiService(IOptions<EndpointsOptions> options) : base(options)
        {
            _baseRoute = options.Value.CommonBase + options.Value.TaskEndpoints.Base;
        }
    }
}
