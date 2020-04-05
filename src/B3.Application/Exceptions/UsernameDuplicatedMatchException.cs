using System;
using B3.Infrastructure.Exceptions;

namespace B3.Application.Exceptions
{
    public class UsernameDuplicatedMatchException : Exception, IApplicationServiceException
    {
        public UsernameDuplicatedMatchException()
            : base("This username is used before by another user!")
        {
        }
    }
}