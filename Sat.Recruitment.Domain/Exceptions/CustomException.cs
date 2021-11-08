using System;

namespace Sat.Recruitment.Domain.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base() { }

        public CustomException(string message) : base(message) { }
    }
}
