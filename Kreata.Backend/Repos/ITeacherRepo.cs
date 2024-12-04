using Kreata.Backend.Datas.Entities;

namespace Kreata.Backend.Repos
{
    public interface ITeacherRepo
    {
        Task<List<Teacher>> GetAll();
        Task<Teacher?> GetBy(Guid id);
        Task<ControllerResponse> UpdateTeacherAsync(Teacher teacher);
        Task<ControllerResponse> DeleteItemAsync(Guid Id);
    }
}