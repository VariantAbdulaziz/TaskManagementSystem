using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Models.Identity;

namespace TaskManagementSystem.Application.Features.Authentication.CQRS.Commands;
public class RegistrationCommand : IRequest<RegistrationResponse>
{
    public RegistrationRequest RegistrationRequest { get; set; }
}
