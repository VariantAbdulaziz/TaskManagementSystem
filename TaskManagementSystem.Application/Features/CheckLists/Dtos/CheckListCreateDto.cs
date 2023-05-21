using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Features.CheckLists.Dtos;
public class CheckListCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int TaskId { get; set; }
}
