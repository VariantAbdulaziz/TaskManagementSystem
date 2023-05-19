using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Exceptions;
public class ValidationException : ApplicationException
{
    public ValidationException(IEnumerable<string> errors) : base("One or more validation failures have occurred.")
    {
        Errors = errors.ToList();
    }

    public IReadOnlyList<string> Errors { get; }
}
