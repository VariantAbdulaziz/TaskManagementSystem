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
public class CreateCheckListCommandHandler : IRequestHandler<CreateCheckListCommand, int>
{
    private readonly ICheckListRepository _checkListRepository;
    private readonly IMapper _mapper;

    public CreateCheckListCommandHandler(ICheckListRepository checkListRepository, IMapper mapper)
    {
        _checkListRepository = checkListRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCheckListCommand request, CancellationToken cancellationToken)
    {
        var validator = new CheckListCreateDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CheckListCreateDto, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors.Select(x => x.ErrorMessage));

        var checkList = _mapper.Map<CheckList>(request.CheckListCreateDto);

        checkList = await _checkListRepository.AddAsync(checkList);

        return checkList.Id;
    }
}
