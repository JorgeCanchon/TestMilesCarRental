﻿using FluentValidation.Results;

namespace MilesCarRental.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException() : base("Se ha producido uno o más errores de validación")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.Select(f => f.ErrorMessage).ToList();
        }
    }
}
