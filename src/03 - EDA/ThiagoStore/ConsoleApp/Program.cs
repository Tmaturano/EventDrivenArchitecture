using System.Threading.Tasks;
using ThiagoStore.Order.Domain.Commands;
using ThiagoStore.Order.Domain.Commands.Handlers;
using ThiagoStore.Order.Infra.ExternalServices;
using ThiagoStore.Order.Infra.Repositories;

namespace ThiagoStore.Order.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var command = new PlaceOrderCommand
            {
                Email = "thiago@email.io"
            };

            var repository = new OrderRepository();
            var paymentService = new PaymentService();
            var kafkaService = new KafkaEventService();

            var handler = new OrderCommandHandler(repository, paymentService, kafkaService);
            handler.SetTopic("payments");

            await handler.HandleAsync(command);
        }
    }
}
