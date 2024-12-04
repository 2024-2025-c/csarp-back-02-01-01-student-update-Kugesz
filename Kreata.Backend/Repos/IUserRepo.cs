using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;

namespace Kreata.Backend.Repos
{
    public interface IUserRepo
    {
        Task<List<User>> GetAll();
        Task<User?> GetBy(Guid Id);
        Task<ControllerResponse> UpdateUserAsync(User user);
        Task<ControllerResponse> DeleteUserAsync(Guid Id);
        Task<ControllerResponse> InsertUserAsync(User user);
    }
}
