using CodinGame.Data;
using System;
using System.Runtime.Serialization;

namespace CodinGame.Exceptions
{
    [Serializable]
    public class CodinGameException : Exception
    {
        public CodinGameException()
        {
        }

        public CodinGameException(string message) : base(message)
        {
        }

        public CodinGameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CodinGameException(Error error) : base($"{error.Code}: {error.Message}")
        {
        }

        protected CodinGameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}