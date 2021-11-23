using System;
using ThiagoStore.SharedContext.Commands;

namespace ThiagoStore.Order.Domain.Commands
{
    //Fail Fast Validation will be here
    public class PayOrderCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
    }
}
