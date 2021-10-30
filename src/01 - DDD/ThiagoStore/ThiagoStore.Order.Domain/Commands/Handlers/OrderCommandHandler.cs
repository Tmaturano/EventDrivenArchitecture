using System;
using System.Threading.Tasks;
using ThiagoStore.Order.Domain.Events;
using ThiagoStore.Order.Domain.ExternalServices;
using ThiagoStore.Order.Domain.Repositories;
using ThiagoStore.Order.Domain.ValueObjects;
using ThiagoStore.SharedContext.Commands.Handlers;
using ThiagoStore.SharedContext.ExternalServices;

namespace ThiagoStore.Order.Domain.Commands.Handlers
{
    //Entry Point. A command will pass through a handler
    public class OrderCommandHandler :
           ICommandHandler<PlaceOrderCommand>,
           ICommandHandler<PayOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IPaymentService _paymentService;
        private readonly IEventService _eventService;

        public OrderCommandHandler(
            IOrderRepository repository,
            IPaymentService paymentService,
            IEventService eventService)
        {
            _repository = repository;
            _paymentService = paymentService;
            _eventService = eventService;
        }

        public async Task HandleAsync(PlaceOrderCommand command)
        {
            // Validate the command
            var user = await _repository.GetUserAsync(command.Email);

            if (user == null)
                return;

            var order = new Entities.Order(user);
            order.OnOrderPlaced += OnOrderPlaced; //using the delegate

            order.Place();
        }

        public async Task HandleAsync(PayOrderCommand command)
        {
            var order = await _repository.GetOrderAsync(command.Id);
            order.OnOrderPaid += OnOrderPaid;

            var creditCard = new CreditCard
            {
                Name = command.Name,
                Number = command.Number,
                Expiration = command.Expiration,
                Cvv = command.Cvv
            };
            var transaction = await _paymentService.PayAsync(creditCard);

            order.Pay(transaction);
        }

        //will be used with Kafka or other messaging
        private async void OnOrderPlaced(object sender, EventArgs e) =>
            await _eventService.QueueAsync(new OrderCreatedEvent((Entities.Order)sender));

        //will be used with Kafka or other messaging
        private async void OnOrderPaid(object sender, EventArgs e) =>
            await _eventService.QueueAsync(new OrderPaidEvent((Entities.Order)sender));
    }
}
