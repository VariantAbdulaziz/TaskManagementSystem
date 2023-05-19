using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Tasks.CQRS.Commands;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Tasks.CQRS.Handlers;
public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var taskToDelete = await _taskRepository.GetByIdAsync(request.Id);

        if (taskToDelete == null)
            throw new NotFoundException(nameof(TaskEntity), request.Id);

        await _taskRepository.DeleteAsync(taskToDelete);

    }
}
