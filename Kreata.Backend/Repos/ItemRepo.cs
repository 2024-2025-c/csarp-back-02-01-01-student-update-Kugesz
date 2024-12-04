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

        // Update the repository method to return Task<ControllerResponse>
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

        public async Task<ControllerResponse> DeleteItemAsync(Guid Id)
        {
            ControllerResponse response = new ControllerResponse();
            Item? itemToDelete = await GetBy(Id);
            if (itemToDelete != null || itemToDelete == default) {
                response.AppendNewError($"{Id} idevel rendelkezo Item nem talalható!");
                response.AppendNewError("Item törlése nem sikerült!");
            }
            else
            {
                _dbContext.ChangeTracker?.Clear();
                _dbContext.Entry(itemToDelete).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            return response;
        }

        public async Task<ControllerResponse> InsertItemAsyn(Item item)
        {
            try
            {
                _dbcontext.add(item);
                await _dbContext.SaveChangesAsync()
                    }
            catch
            {
                ControllerResponse response = new ControllerResponse();
                response.AppendNewError($"{item.Name} nem hozzaadható!");
                response.AppendNewError("A hozzáadás nem lehetséges!")
            }
        }
    }
}
