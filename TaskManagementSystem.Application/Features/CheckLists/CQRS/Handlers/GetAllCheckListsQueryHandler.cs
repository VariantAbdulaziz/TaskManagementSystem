using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Contracts.Persitence;
using TaskManagementSystem.Application.Features.CheckLists.CQRS.Queries;
using TaskManagementSystem.Application.Features.CheckLists.Dtos;

namespace TaskManagementSystem.Application.Features.CheckLists.CQRS.Handlers;
public class GetAllCheckListsQueryHandler : IRequestHandler<GetAllCheckListsQuery, List<CheckListDto>>
{
    private readonly ICheckListRepository _checkListRepository;
    private readonly IMapper _mapper;

    public GetAllCheckListsQueryHandler(ICheckListRepository checkListRepository, IMapper mapper)
    {
        _checkListRepository = checkListRepository;
        _mapper = mapper;
    }

    public async Task<List<CheckListDto>> Handle(GetAllCheckListsQuery request, CancellationToken cancellationToken)
    {
        var checkLists = await _checkListRepository.GetAllAsync();

        return _mapper.Map<List<CheckListDto>>(checkLists);
    }
}
