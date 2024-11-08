using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;

namespace Kreata.Backend.Repos
{
    public interface IOrderRepo
    {
        Task<List<Order>> GetAll();
        Task<Order?> GetBy(Guid Id);
        Task<ControllerResponse> UpdateOrderAsync(Order order);
    }
}
