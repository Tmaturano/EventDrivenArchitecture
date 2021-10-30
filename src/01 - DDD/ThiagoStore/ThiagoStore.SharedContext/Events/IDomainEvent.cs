using System;

namespace ThiagoStore.SharedContext.Events
{
    public interface IDomainEvent
    {
        public DateTime OccuredAt { get; set; }
    }
}
