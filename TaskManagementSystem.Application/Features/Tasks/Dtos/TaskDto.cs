using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Tasks.Dtos;
public class TaskDto
{
    public int Id { get; set; }
    public string ApplicationUserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCompleted { get; set; }
    public ICollection<CheckList> CheckLists { get; set; }
}
