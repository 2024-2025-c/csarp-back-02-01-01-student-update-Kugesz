using Kreata.Backend.Datas.Entities;

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
