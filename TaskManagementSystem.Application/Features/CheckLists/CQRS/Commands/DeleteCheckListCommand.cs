using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Features.CheckLists.CQRS.Commands;
public class DeleteCheckListCommand : IRequest
{
    public int Id { get; set; }
}
