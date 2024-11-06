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

        public Task UpdateItemAsync(Item item)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(item).State = EntityState.Modified;
            throw new NotImplementedException();
        }


    }
}
