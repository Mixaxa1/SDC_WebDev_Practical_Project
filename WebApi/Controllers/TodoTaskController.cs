using Application.ListLogic.Commands.DeleteList;
using Application.TaskLogic.Commands.CreateTask;
using Application.TaskLogic.Commands.DeleteTask;
using Application.TaskLogic.Commands.UpdateTask;
using Application.TaskLogic.Queries.GetTaskById;
using Application.TaskLogic.RequestDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoTaskController : TodoController
{

    public TodoTaskController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoTaskRequestDto dto)
    {
        var task = await Mediator.Send(new CreateTodoTaskCommand(dto));

        if (task == null)
        {
            return BadRequest();
        }

        return Ok(task);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var task = await Mediator.Send(new GetTaskByIdQuery(id));

        if (task == null)
        {
            return BadRequest();
        }

        return Ok(task);
    }

    [HttpPut]
    public async Task<IActionResult> Update(CreateTodoTaskRequestDto dto)
    {
        var task = await Mediator.Send(new UpdateTodoTaskCommand(dto));

        if (task == null)
        {
            return BadRequest();
        }

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteTodoTaskCommand(id));

        return Ok();
    }
}
