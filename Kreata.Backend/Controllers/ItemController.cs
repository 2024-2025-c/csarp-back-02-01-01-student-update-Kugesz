using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private IItemRepo _itemRepo;

        public ItemController(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Item>? users = new();

            if (_itemRepo != null)
            {
                users = await _itemRepo.GetAll();
                return Ok(users);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Item? entity = new();
            if (_itemRepo is not null)
            {
                entity = await _itemRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync(Guid Id)
        {
            ControllerResponse response = new();
            if (_itemRepo is not null)
            {
                response = await _itemRepo.DeleteItemAsync(Id);
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

        [HttpPut()]
        public async Task<ActionResult> UpdateItemAsync(Item entity)
        {
            ControllerResponse response = new();
            if (_itemRepo is not null)
            {
                response = await _itemRepo.UpdateItemAsync(entity);
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

       

        [HttpPost()]
        public async Task<IActionResult> InsertItemAsync(Item item)
        {
            ControllerResponse response = new();
            if (_itemRepo is not null)
            {
                response = await _itemRepo.InsertItemAsync(item);
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
