using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.CheckLists.CQRS.Commands;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.CheckLists.CQRS.Handlers;
public class DeleteCheckListCommandHandler : IRequestHandler<DeleteCheckListCommand>
{
    private readonly ICheckListRepository _checkListRepository;

    public DeleteCheckListCommandHandler(ICheckListRepository checkListRepository)
    {
        _checkListRepository = checkListRepository;
    }

    public async Task Handle(DeleteCheckListCommand request, CancellationToken cancellationToken)
    {
        var checkListToDelete = await _checkListRepository.GetByIdAsync(request.Id);

        if (checkListToDelete == null)
            throw new NotFoundException(nameof(CheckList), request.Id);

        await _checkListRepository.DeleteAsync(checkListToDelete);

    }
}
