using System.Threading.Tasks;
using ThiagoStore.Order.Domain.Entities;
using ThiagoStore.Order.Domain.ExternalServices;
using ThiagoStore.Order.Domain.ValueObjects;

namespace ThiagoStore.Order.Infra.ExternalServices
{
    public class PaymentService : IPaymentService
    {
        public async Task<Transaction> PayAsync(CreditCard creditCard)
        {
            await Task.Delay(5);
            return new Transaction(new CreditCard
            {
                Name = "JOHN WICK",
                Number = "4111111111111111",
                Expiration = "05/29",
                Cvv = "123"
            });
        }
    }
}
