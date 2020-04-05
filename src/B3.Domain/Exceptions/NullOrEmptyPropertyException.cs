using System;
using B3.Infrastructure.Exceptions;

namespace B3.Domain.Exceptions
{
    public class NullOrEmptyPropertyException : Exception, IDomainException
    {
        public NullOrEmptyPropertyException(string name)
            : base($"{name} property has null value!")
        {
        }
    }
}