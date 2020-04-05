using System;
using B3.Infrastructure.Exceptions;

namespace B3.Domain.Exceptions
{
    public class InvalidPropertyFormatException : Exception, IDomainException
    {
        public InvalidPropertyFormatException(string name)
            : base($"{name} property has invalid format!")
        {
        }
    }
}