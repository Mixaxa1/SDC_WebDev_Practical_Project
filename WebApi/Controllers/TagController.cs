using Application.ListLogic.Commands.DeleteList;
using Application.ListLogic.Queries.GetListById;
using Application.TagLogic.Commands.CreateTag;
using Application.TagLogic.Commands.DeleteTag;
using Application.TagLogic.Queris.GetAllTags;
using Application.TagLogic.Queris.GetTagById;
using Application.TagLogic.RequestDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : TodoController
{
    public TagController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TagRequestDto dto)
    {
        var tag = await Mediator.Send(new CreateTagCommand(dto));

        if (tag == null)
        {
            return BadRequest();
        }

        return Ok(tag);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var tag = await Mediator.Send(new GetTagByIdQuery(id));

        if (tag == null)
        {
            return NotFound();
        }

        return Ok(tag);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tags = await Mediator.Send(new GetAllTagsQuery());

        return Ok(tags);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteTagCommand(id));

        return Ok();
    }
}
