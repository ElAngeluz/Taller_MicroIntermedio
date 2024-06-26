﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Taller.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("No se ha podido superar alguna validacionesm por favor revisar.")
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}