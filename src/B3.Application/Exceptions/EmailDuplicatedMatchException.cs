using System;
using B3.Infrastructure.Exceptions;

namespace B3.Application.Exceptions
{
    public class EmailDuplicatedMatchException : Exception, IApplicationServiceException
    {
        public EmailDuplicatedMatchException()
            : base("This email is used before by another user!")
        {
        }
    }
}