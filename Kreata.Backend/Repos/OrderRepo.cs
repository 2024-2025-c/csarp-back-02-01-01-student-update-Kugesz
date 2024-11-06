using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public OrderRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order?> GetBy(Guid id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(s => s.OrderId == id);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public Task UpdateOrderAsync(Order order)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(order).State = EntityState.Modified;
            throw new NotImplementedException();
        }
    }
}
