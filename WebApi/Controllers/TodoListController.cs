using Application.ListLogic.Commands.CreateList;
using Application.ListLogic.Commands.DeleteList;
using Application.ListLogic.Commands.UpdateList;
using Application.ListLogic.Queries.GetAllLists;
using Application.ListLogic.Queries.GetListById;
using Application.ListLogic.RequestDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListController : TodoController
{

    public TodoListController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoListRequestDto dto)
    {
        var list = await Mediator.Send(new CreateTodoListCommand(dto));

        if (list == null)
        {
            return BadRequest();
        }

        return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, [FromQuery] bool withIncludes)
    {
        var list = await Mediator.Send(new GetTodoListByIdQuery(id, withIncludes));

        if (list == null)
        {
            return NotFound();
        }

        return Ok(list);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lists = await Mediator.Send(new GetAllTodoListsQuery());

        return Ok(lists);
    }

    [HttpPut]
    public async Task<IActionResult> Update(CreateTodoListRequestDto dto)
    {
        var list = await Mediator.Send(new UpdateTodoListCommand(dto));

        if (list == null)
        {
            return NotFound();
        }

        return Ok(list);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteTodoListCommand(id));

        return Ok();
    }
}
