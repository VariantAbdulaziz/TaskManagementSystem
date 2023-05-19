using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Contracts.Persitence;
public interface ICheckListRepository : IGenericRepository<CheckList>
{
}
