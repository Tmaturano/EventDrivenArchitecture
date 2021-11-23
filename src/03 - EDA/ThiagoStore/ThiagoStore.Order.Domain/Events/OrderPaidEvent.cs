using System;
using ThiagoStore.SharedContext.Events;

namespace ThiagoStore.Order.Domain.Events
{
    public class OrderPaidEvent : IDomainEvent
    {
        public OrderPaidEvent(Entities.Order order)
        {
            Id = Guid.NewGuid();
            Order = order;
            OccuredAt = DateTime.Now;
        }

        public DateTime OccuredAt { get; set; }
        public Entities.Order Order { get; set; }
        public Guid Id { get; set; }
    }
}
