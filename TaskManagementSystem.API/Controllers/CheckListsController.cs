using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Features.CheckLists.CQRS.Commands;
using TaskManagementSystem.Application.Features.CheckLists.CQRS.Queries;
using TaskManagementSystem.Application.Features.CheckLists.Dtos;

namespace TaskManagementSystem.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CheckListsController : ControllerBase
{
    public readonly IMediator _mediator;
    public CheckListsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet] //api/CheckList
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetAllCheckListsQuery()));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _mediator.Send(new GetCheckListByIdQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CheckListCreateDto createCheckList)
    {
        return Ok(await _mediator.Send(new CreateCheckListCommand { CheckListCreateDto = createCheckList }));
    }


    [HttpPut]
    public async Task<IActionResult> Update(CheckListUpdateDto updateCheckList)
    {
        await _mediator.Send(new UpdateCheckListCommand { CheckListUpdateDto = updateCheckList });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActvity(int id)
    {
        await _mediator.Send(new DeleteCheckListCommand { Id = id });
        return NoContent();
    }
}
