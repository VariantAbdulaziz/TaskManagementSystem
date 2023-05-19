using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Features.Tasks.CQRS.Queries;
using TaskManagementSystem.Application.Features.Tasks.Dtos;

namespace TaskManagementSystem.Application.Features.Tasks.CQRS.Handlers;
public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskDto>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public GetAllTasksQueryHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync();

        return _mapper.Map<List<TaskDto>>(tasks);
    }
}