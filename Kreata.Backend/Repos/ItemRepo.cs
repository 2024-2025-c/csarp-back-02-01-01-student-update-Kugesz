using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

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
                response.AppendNewError($"{nameof(ItemRepo)} osztály, {nameof(UpdateItemAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{item} frissítése nem sikerült!");
            }
            return response;
        }
    }
}
