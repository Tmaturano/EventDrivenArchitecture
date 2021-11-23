using System.Threading.Tasks;
using ThiagoStore.SharedContext.Events;

namespace ThiagoStore.SharedContext.ExternalServices
{
    //Simple interface, that can be used with any services (Kafka, RabbitMQ, Azure Service Bus, etc)
    public interface IEventService
    {
        public Task Queue(IDomainEvent evt, string topic);
    }
}
