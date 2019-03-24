using System;

namespace LAB
{
    public class ConnectionException : ApplicationException
    {
        public ConnectionException(){}

        public ConnectionException(string message) : base(message){}

        public ConnectionException(string message, Exception inner) : base(message, inner){}
    }
}
