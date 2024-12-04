using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;

namespace Kreata.Backend.Repos
{
    public interface IParentRepo
    {
        Task<List<Parent>> GetAll();
        Task<Parent?> GetBy(Guid id);
        Task<ControllerResponse> UpdateParentAsync(Parent parent);
        Task<ControllerResponse> DeleteParentAsync(Guid Id);
        Task<ControllerResponse> InsertParentAsync(Parent parent);
    }
}
