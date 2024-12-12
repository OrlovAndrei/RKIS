using System;

namespace Passwords
{
    public class AssertionException : Exception
    {
        public AssertionException(string message, params object[] args)
            : base(string.Format(message, args))
        {

        }
    }
}