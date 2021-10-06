using System;
using System.Runtime.Serialization;

namespace CodeCompanion.EntityFrameworkCore
{
    public class HotSaveDisabledException : Exception
    {
        public HotSaveDisabledException() : this("Hot save is disabled")
        {
        }

        public HotSaveDisabledException(string? message) : base(message)
        {
        }

        public HotSaveDisabledException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HotSaveDisabledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}