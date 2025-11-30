using Microsoft.Extensions.Options;
using WebApp.Models.TodoTask;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices
{
    public class TodoTaskApiService : ApiService<TodoTaskModel>, ITodoTaskApiService
    {
        public TodoTaskApiService(IOptions<EndPointsOptions> options) : base(options)
        {
            Route = options.Value.CommonBase + options.Value.TodoTaskBase;
        }
    }
}
