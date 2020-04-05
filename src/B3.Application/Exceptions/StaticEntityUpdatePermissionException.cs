using System;
using B3.Infrastructure.Exceptions;

namespace B3.Application.Exceptions
{
    public class StaticEntityUpdatePermissionException : Exception, IApplicationServiceException
    {
        public StaticEntityUpdatePermissionException(string name)
            : base($"Static {name} cannot be updated!")
        {
        }
    }
}