using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Features.CheckLists.Dtos;
using TaskManagementSystem.Application.Features.Tasks.Dtos;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CheckList mappings
        CreateMap<CheckList, CheckListDto>().ReverseMap();
        CreateMap<CheckListCreateDto, CheckList>().ReverseMap();
        CreateMap<CheckListUpdateDto, CheckList>().ReverseMap();

        // Task mappings
        CreateMap<TaskEntity, TaskDto>().ReverseMap();
        CreateMap<TaskCreateDto, TaskEntity>().ReverseMap();
        CreateMap<TaskUpdateDto, TaskEntity>().ReverseMap();
    }
}