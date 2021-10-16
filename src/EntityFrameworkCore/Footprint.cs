using System;

namespace CodeCompanion.EntityFrameworkCore
{
    public struct Footprint
    {
        public readonly int? UserId;
        public readonly DateTimeOffset? Timestamp;

        public Footprint(int? userId, DateTimeOffset? timestamp)
        {
            UserId = userId;
            Timestamp = timestamp;
        }
    }
}