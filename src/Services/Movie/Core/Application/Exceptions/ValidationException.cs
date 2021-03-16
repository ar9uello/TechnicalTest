using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace TechnicalTest.Movie.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }

        public override string ToString()
        {
            return string.Join("; ", ValdationErrors);
        }
    }
}
