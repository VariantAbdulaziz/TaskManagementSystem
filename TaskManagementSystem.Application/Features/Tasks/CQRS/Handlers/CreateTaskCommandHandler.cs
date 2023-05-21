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
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var validator = new TaskCreateDtoValidator();
        var validationResult = await validator.ValidateAsync(request.TaskCreateDto, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors.Select(x => x.ErrorMessage));

        var task = _mapper.Map<TaskEntity>(request.TaskCreateDto);

        task = await _taskRepository.AddAsync(task);

        return task.Id;
    }
}
