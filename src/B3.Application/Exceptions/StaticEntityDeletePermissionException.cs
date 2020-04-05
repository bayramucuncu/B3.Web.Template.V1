using System;
using B3.Infrastructure.Exceptions;

namespace B3.Application.Exceptions
{
    public class StaticEntityDeletePermissionException : Exception, IApplicationServiceException
    {
        public StaticEntityDeletePermissionException(string name)
            : base($"Static {name} cannot be deleted!")
        {
        }
    }
}