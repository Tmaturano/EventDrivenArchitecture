using ThiagoStore.SharedContext.Events.Handlers;

namespace ThiagoStore.Order.Domain.Events.Handlers
{
    public class OrderEventHandler : IEventHandler<OrderPaidEvent>
    {
        public void Handle(OrderPaidEvent command)
        {
            throw new System.NotImplementedException();
        }
    }
}
