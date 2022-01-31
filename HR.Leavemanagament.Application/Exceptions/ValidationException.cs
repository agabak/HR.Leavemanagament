using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.Leavemanagament.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {

        // look into this , something is not right

        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors.Select(x => x.ErrorMessage))
            {
                Errors.Add(error);
            }
        }
    }
}
