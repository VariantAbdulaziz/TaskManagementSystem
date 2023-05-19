using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Features.Tasks.Dtos;

namespace TaskManagementSystem.Application.Features.Tasks.CQRS.Queries;
public class GetTaskByIdQuery : IRequest<TaskDto>
{
    public int Id { get; set; }
}
