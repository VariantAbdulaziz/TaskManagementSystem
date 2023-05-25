using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Features.Tasks.CQRS.Queries;
using TaskManagementSystem.Application.Features.Tasks.Dtos;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.API.Authorizations;

public class ResourceOwnerHandler : AuthorizationHandler<ResourceOwnerRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITaskRepository _taskRepository;
    private readonly IActionContextAccessor _actionContextAccessor;

    public ResourceOwnerHandler(IHttpContextAccessor httpContextAccessor, ITaskRepository taskRepository, IActionContextAccessor actionContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _taskRepository = taskRepository;
        _actionContextAccessor = actionContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor)); ;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        ResourceOwnerRequirement requirement)
    {
        var userId = _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(q => q.Type == "uid")?.Value;

        object? id;
        _httpContextAccessor.HttpContext.Request.RouteValues.TryGetValue("id", out id);
        var task = await _taskRepository.GetByIdAsync(Int32.Parse(id as string));
        if (userId == task.ApplicationUserId)
        {
            context.Succeed(requirement);
        }
    }
}
