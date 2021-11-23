using System;
using ThiagoStore.SharedContext.Events;

namespace ThiagoStore.Order.Domain.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public OrderCreatedEvent(Entities.Order order)
        {
            Id = Guid.NewGuid();
            Order = order;
            OccuredAt = DateTime.Now;
        }

        public Entities.Order Order { get; set; }
        public DateTime OccuredAt { get; set; }
        public Guid Id { get; set; }
    }
}
