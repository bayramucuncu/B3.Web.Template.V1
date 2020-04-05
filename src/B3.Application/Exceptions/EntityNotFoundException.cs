using System;
using B3.Infrastructure.Exceptions;

namespace B3.Application.Exceptions
{
    public class EntityNotFoundException : Exception, INotFountException
    {
        public EntityNotFoundException(string name)
            : base($"{name} could not found!")
        {
        }
    }
}