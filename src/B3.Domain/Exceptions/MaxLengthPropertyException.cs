using System;
using B3.Infrastructure.Exceptions;

namespace B3.Domain.Exceptions
{
    public class MaxLengthPropertyException : Exception, IDomainException
    {
        public MaxLengthPropertyException(string name, int length)
            : base($"{name} property length must be {length} character long or less!")
        {
        }
    }
}