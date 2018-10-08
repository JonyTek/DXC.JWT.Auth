using System;

namespace DXC.JWT.Auth.Core
{
    public class UnknownUserException : Exception
    {
        private const string message = "Invalid email and/or password";

        public UnknownUserException() : base(message)
        {
        }
    }
}