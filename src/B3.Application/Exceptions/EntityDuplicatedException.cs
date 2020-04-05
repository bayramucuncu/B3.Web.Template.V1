using System;
using B3.Infrastructure.Exceptions;

namespace B3.Application.Exceptions
{
    public class EntityDuplicatedException : Exception, IApplicationServiceException
    {
        public EntityDuplicatedException()
            : base($"This record is already exist!")
        {
        }
    }
}