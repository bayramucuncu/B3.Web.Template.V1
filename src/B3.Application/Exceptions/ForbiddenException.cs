using System;
using B3.Infrastructure.Exceptions;

namespace B3.Application.Exceptions
{
    public class ForbiddenException : Exception, IUnauthorizedException
    {
        public ForbiddenException()
            : base("You do not have permissions for this operation!")
        {
        }
    }
}