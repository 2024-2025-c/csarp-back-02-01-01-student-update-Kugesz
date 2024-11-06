using Kreata.Backend.Datas.Entities;

namespace Kreata.Backend.Repos
{
    public interface IOrderRepo
    {
        Task<List<Order>> GetAll();
        Task<Order?> GetBy(Guid Id);
    }
}
