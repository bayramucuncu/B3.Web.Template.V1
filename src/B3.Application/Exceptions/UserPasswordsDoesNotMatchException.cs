using System;
using B3.Infrastructure.Exceptions;

namespace B3.Application.Exceptions
{
    public class UserPasswordsDoesNotMatchException : Exception, IApplicationServiceException
    {
        public UserPasswordsDoesNotMatchException()
            : base("New Passwords does not match!")
        {
        }
    }
}