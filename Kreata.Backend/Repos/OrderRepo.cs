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

        public async Task<ControllerResponse> UpdateOrderAsync(Order order)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(order).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(OrderRepo)} osztály, {nameof(UpdateOrderAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{order} frissítése nem sikerült!");
            }
            return response;
        }

        public async Task<ControllerResponse> DeleteOrderAsync(Guid Id)
        {
            ControllerResponse response = new ControllerResponse();
            Order? orderToDelete = await GetBy(Id);
            if (orderToDelete != null || orderToDelete == default)
            {
                response.AppendNewError($"{Id} idevel rendelkezo Order nem talalható!");
                response.AppendNewError("Item törlése nem sikerült!");
            }
            else
            {
                _dbContext.ChangeTracker?.Clear();
                _dbContext.Entry(orderToDelete).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            return response;
        }

        public async Task<ControllerResponse> InsertOrderAsync(Order order)
        {
                ControllerResponse response = new ControllerResponse();
            try
            {
                _dbContext.Add(order);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                response.AppendNewError($"{order} nem hozzaadható!");
                response.AppendNewError("A hozzáadás nem lehetséges!");
            }
            return response;
        }
        }
    }

