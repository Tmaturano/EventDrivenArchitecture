using System;

namespace ThiagoStore.SharedContext.Events
{
    public interface IDomainEvent
    {
        public Guid Id { get; set; }
        public DateTime OccuredAt { get; set; }
    }
}
