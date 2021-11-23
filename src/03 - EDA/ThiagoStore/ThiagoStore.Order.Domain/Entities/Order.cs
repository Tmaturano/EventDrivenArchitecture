using System;
using System.Collections.Generic;
using ThiagoStore.SharedContext.Entities;

namespace ThiagoStore.Order.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public Order(User user)
        {
            User = user;
            LastUpdateDate = DateTime.Now;
        }

        private List<Transaction> _transactions = new();

        public event EventHandler OnOrderPlaced;
        public event EventHandler OnOrderPaid;

        public User User { get; }
        public DateTime LastUpdateDate { get; private set; }
        public IReadOnlyCollection<Transaction> Transactions => _transactions;

        // This way we avoid having the dependency of the service class (e.g kafka service) in this domain class.
        // we invoke an event that has been delegated previously (check OrderCommandHandler.cs / HandleAsync)
        public void Place()
        {
            LastUpdateDate = DateTime.Now;

            var args = EventArgs.Empty; 
            var handler = OnOrderPlaced;
            handler?.Invoke(this, args);
        }

        public void Pay(Transaction transaction)
        {
            LastUpdateDate = DateTime.Now;
            _transactions.Add(transaction);
        }
    }
}
