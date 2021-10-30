using System.Threading.Tasks;
using ThiagoStore.SharedContext.Events;
using ThiagoStore.SharedContext.ExternalServices;

namespace ThiagoStore.Order.Infra.ExternalServices
{
    public class EventService : IEventService
    {
        public Task QueueAsync(IDomainEvent evt)
        {
            throw new System.NotImplementedException();
        }
    }
}
