using ThiagoStore.Order.Domain.ValueObjects;

namespace ThiagoStore.Order.Domain.Entities
{
    public class Transaction
    {
        public Transaction(CreditCard creditCard) => CreditCard = creditCard;

        public CreditCard CreditCard { get; }
    }
}
