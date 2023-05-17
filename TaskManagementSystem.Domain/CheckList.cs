using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain;
public class CheckList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int TaskId { get; set; }
    public bool IsCompleted { get; set; }
    public Task Task { get; set; }
}