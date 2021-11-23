using System;
using System.Threading.Tasks;
using ThiagoStore.Order.Domain.Entities;
using ThiagoStore.Order.Domain.Repositories;

namespace ThiagoStore.Order.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<User> GetUserAsync(string email)
        {
            await Task.Delay(12);
            return new User(email);
        }

        public async Task<Domain.Entities.Order> GetOrderAsync(Guid id)
        {
            await Task.Delay(18);
            var user = await GetUserAsync("hello@test.com");
            return new Domain.Entities.Order(user);
        }
    }
}
