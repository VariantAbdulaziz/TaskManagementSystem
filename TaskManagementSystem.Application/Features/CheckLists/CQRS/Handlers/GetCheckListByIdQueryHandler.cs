using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.CheckLists.CQRS.Queries;
using TaskManagementSystem.Application.Features.CheckLists.Dtos;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.CheckLists.CQRS.Handlers;
public class GetCheckListByIdQueryHandler : IRequestHandler<GetCheckListByIdQuery, CheckListDto>
{
    private readonly ICheckListRepository _checkListRepository;
    private readonly IMapper _mapper;

    public GetCheckListByIdQueryHandler(ICheckListRepository checkListRepository, IMapper mapper)
    {
        _checkListRepository = checkListRepository;
        _mapper = mapper;
    }

    public async Task<CheckListDto> Handle(GetCheckListByIdQuery request, CancellationToken cancellationToken)
    {
        var checkList = await _checkListRepository.GetByIdAsync(request.Id);

        if (checkList == null)
            throw new NotFoundException(nameof(CheckList), request.Id);

        return _mapper.Map<CheckListDto>(checkList);
    }
}
