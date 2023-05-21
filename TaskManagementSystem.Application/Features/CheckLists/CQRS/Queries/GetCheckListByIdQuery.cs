using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Features.CheckLists.Dtos;

namespace TaskManagementSystem.Application.Features.CheckLists.CQRS.Queries;
public class GetCheckListByIdQuery : IRequest<CheckListDto>
{
    public int Id { get; set; }
}