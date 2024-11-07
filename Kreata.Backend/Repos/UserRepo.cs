using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public UserRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetBy(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<ControllerResponse> UpdateUserAsync(User user)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(UserRepo)} osztály, {nameof(UpdateUserAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{user} frissítése nem sikerült!");
            }
            return response;
        }
    }
}
