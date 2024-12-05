using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class ParentRepo : IParentRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public ParentRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Parent?> GetBy(Guid id)
        {
            return await _dbContext.Parents.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Parent>> GetAll()
        {
            return await _dbContext.Parents.ToListAsync();
        }

        public async Task<ControllerResponse> UpdateParentAsync(Parent parent)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(parent).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(ParentRepo)} osztály, {nameof(UpdateParentAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{parent} frissítése nem sikerült!");
            }
            return response;
        }

        public async Task<ControllerResponse> DeleteParentAsync(Guid Id)
        {
            ControllerResponse response = new ControllerResponse();
            Parent? parentToDelete = await GetBy(Id);
            if (parentToDelete == null || parentToDelete == default)
            {
                response.AppendNewError($"{Id} idevel rendelkezo Parent nem talalható!");
                response.AppendNewError("Item törlése nem sikerült!");
            }
            else
            {
                _dbContext.ChangeTracker?.Clear();
                _dbContext.Entry(parentToDelete).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            return response;
        }

        public async Task<ControllerResponse> InsertParentAsync(Parent parent)
        {
                ControllerResponse response = new ControllerResponse();
            try
            {
                _dbContext.Add(parent);
                await _dbContext.SaveChangesAsync();
                    }
            catch
            {
                response.AppendNewError($"{parent} nem hozzaadható!");
                response.AppendNewError("A hozzáadás nem lehetséges!");
            }
            return response;
        }
    }
}
