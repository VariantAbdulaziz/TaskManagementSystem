using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.CheckLists.CQRS.Commands;
using TaskManagementSystem.Application.Features.CheckLists.Dtos.Validation;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.CheckLists.CQRS.Handlers;
public class UpdateCheckListCommandHandler : IRequestHandler<UpdateCheckListCommand>
{
    private readonly ICheckListRepository _checkListRepository;
    private readonly IMapper _mapper;

    public UpdateCheckListCommandHandler(ICheckListRepository checkListRepository, IMapper mapper)
    {
        _checkListRepository = checkListRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCheckListCommand request, CancellationToken cancellationToken)
    {
        var validator = new CheckListUpdateDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CheckListUpdateDto, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors.Select(x => x.ErrorMessage));

        var checkListToUpdate = await _checkListRepository.GetByIdAsync(request.CheckListUpdateDto.Id);

        if (checkListToUpdate == null)
            throw new NotFoundException(nameof(CheckList), request.CheckListUpdateDto.Id);

        _mapper.Map(request.CheckListUpdateDto, checkListToUpdate);

        await _checkListRepository.UpdateAsync(checkListToUpdate);

    }
}
