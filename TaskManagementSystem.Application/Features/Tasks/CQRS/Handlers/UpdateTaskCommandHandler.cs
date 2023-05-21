using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Tasks.CQRS.Commands;
using TaskManagementSystem.Application.Features.Tasks.Dtos.Validation;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Tasks.CQRS.Handlers;
public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public UpdateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var validator = new TaskUpdateDtoValidator();
        var validationResult = await validator.ValidateAsync(request.TaskUpdateDto, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors.Select(x => x.ErrorMessage));

        var taskToUpdate = await _taskRepository.GetByIdAsync(request.TaskUpdateDto.Id);

        if (taskToUpdate == null)
            throw new NotFoundException(nameof(TaskEntity), request.TaskUpdateDto.Id);

        _mapper.Map(request.TaskUpdateDto, taskToUpdate);

        await _taskRepository.UpdateAsync(taskToUpdate);

    }
}
