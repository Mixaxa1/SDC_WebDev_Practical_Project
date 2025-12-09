using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TodoController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public TodoController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
