using System.Threading.Tasks;
using ThiagoStore.Order.Domain.Entities;
using ThiagoStore.Order.Domain.ValueObjects;

namespace ThiagoStore.Order.Domain.ExternalServices
{
    public interface IPaymentService
    {
        public Task<Transaction> PayAsync(CreditCard creditCard);
    }
}
