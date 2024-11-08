using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;

namespace Kreata.Backend.Repos
{
    public interface IItemRepo
    {
        Task<List<Item>> GetAll();
        Task<Item?> GetBy(Guid Id);
        Task<ControllerResponse> UpdateItemAsync(Item item);
    }
}
