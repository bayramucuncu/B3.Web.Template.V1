using System;
using B3.Infrastructure.Exceptions;

namespace B3.Domain.Exceptions
{
    public class MinLengthPropertyException : Exception, IDomainException
    {
        public MinLengthPropertyException(string name, int length)
            : base($"{name} property length must be {length} character long or greater!")
        {
        }
    }
}