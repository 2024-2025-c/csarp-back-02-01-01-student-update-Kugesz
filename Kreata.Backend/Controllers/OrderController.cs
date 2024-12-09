using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderRepo _orderRepo;

        public OrderController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Order? entity = new();
            if (_orderRepo is not null)
            {
                entity = await _orderRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Order>? users = new();

            if (_orderRepo != null)
            {
                users = await _orderRepo.GetAll();
                return Ok(users);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateOrderAsync(Order entity)
        {
            ControllerResponse response = new();
            if (_orderRepo is not null)
            {
                response = await _orderRepo.UpdateOrderAsync(entity);
                if (response.HasError)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(Guid Id)
        {
            ControllerResponse response = new();
            if (_orderRepo is not null)
            {
                response = await _orderRepo.DeleteOrderAsync(Id);
                if (response.HasError)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adat törlése nem lehetséges");
            return BadRequest(response);
        }

        [HttpPost()]
        public async Task<IActionResult> InsertOrderAsync(Order order)
        {
            ControllerResponse response = new();
            if (_orderRepo is not null)
            {
                response = await _orderRepo.InsertOrderAsync(order);
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok hozzáadása nem lehetséges!");
            return BadRequest(response);
        }
    }
}
