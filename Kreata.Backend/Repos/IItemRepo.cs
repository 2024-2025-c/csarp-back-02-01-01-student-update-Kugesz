using Kreata.Backend.Datas.Entities;

namespace Kreata.Backend.Repos
{
    public interface IItemRepo
    {
        Task<List<Item>> GetAll();
        Task<Item?> GetBy(Guid Id);

        Task UpdateItemAsync(Item item);
    }
}
