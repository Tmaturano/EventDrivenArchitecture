using System;
using System.Threading.Tasks;
using ThiagoStore.Order.Domain.Entities;

namespace ThiagoStore.Order.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<User> GetUserAsync(string email);
        public Task<Entities.Order> GetOrderAsync(Guid id);
    }
}
