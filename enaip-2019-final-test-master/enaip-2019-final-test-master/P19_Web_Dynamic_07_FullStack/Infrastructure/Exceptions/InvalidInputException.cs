using System;

namespace P19_Web_Dynamic_07_FullStack.Infrastructure.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException()
        { }

        public InvalidInputException(string message)
            : base(message)
        { }

        public InvalidInputException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
