using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Kreata.Backend.Datas.Responses;

namespace Kreata.Backend.Repos
{
    public class ItemRepo : IItemRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public ItemRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Item?> GetBy(Guid id)
        {
            return await _dbContext.Items.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Item>> GetAll()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task<ControllerResponse> UpdateItemAsync(Item item)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(item).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(ItemRepo)} class, {nameof(UpdateItemAsync)} method encountered an error");
                response.AppendNewError($"Failed to update {item}!");
            }
            return response;
        }

        public async Task<ControllerResponse> DeleteItemAsync(Guid id)
        {
            ControllerResponse response = new ControllerResponse();
            Item? itemToDelete = await GetBy(id);
            if (itemToDelete == null)
            {
                response.AppendNewError($"Item with Id {id} not found!");
                response.AppendNewError("Failed to delete item!");
            }
            else
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry(itemToDelete).State = EntityState.Deleted;
                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    response.AppendNewError(e.Message);
                    response.AppendNewError($"{nameof(ItemRepo)} class, {nameof(DeleteItemAsync)} method encountered an error");
                    response.AppendNewError($"Failed to delete {itemToDelete}!");
                }
            }
            return response;
        }

        public async Task<ControllerResponse> InsertItemAsync(Item item)
        {
                ControllerResponse response = new ControllerResponse();
            try
            {
                _dbContext.Add(item);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                response.AppendNewError($"{item.Name} nem hozzaadható!");
                response.AppendNewError("A hozzáadás nem lehetséges!");
            }
            return response;
        }
    }
}
