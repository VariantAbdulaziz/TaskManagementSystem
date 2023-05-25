using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Features.CheckLists.CQRS.Commands;
using TaskManagementSystem.Application.Features.CheckLists.CQRS.Queries;
using TaskManagementSystem.Application.Features.CheckLists.Dtos;
using TaskManagementSystem.Application.Features.Tasks.CQRS.Commands;
using TaskManagementSystem.Application.Features.Tasks.CQRS.Queries;
using TaskManagementSystem.Application.Features.Tasks.Dtos;

namespace TaskManagementSystem.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TasksController : ControllerBase
{
    public readonly IMediator _mediator;
    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetAllTasksQuery()));
    }

    [Authorize(Policy = "ResourceOwner")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _mediator.Send(new GetTaskByIdQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskCreateDto createTask)
    {
        return Ok(await _mediator.Send(new CreateTaskCommand { TaskCreateDto = createTask }));
    }


    [HttpPut]
    public async Task<IActionResult> Update(TaskUpdateDto updateTask)
    {
        await _mediator.Send(new UpdateTaskCommand { TaskUpdateDto = updateTask });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActvity(int id)
    {
        await _mediator.Send(new DeleteTaskCommand { Id = id });
        return NoContent();
    }
}
