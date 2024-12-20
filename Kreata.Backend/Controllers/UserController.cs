using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            User? entity = new();
            if (_userRepo is not null)
            {
                entity = await _userRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<User>? users = new();

            if (_userRepo != null)
            {
                users = await _userRepo.GetAll();
                return Ok(users);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateUserAsync(User entity)
        {
            ControllerResponse response = new();
            if (_userRepo is not null)
            {
                response = await _userRepo.UpdateUserAsync(entity);
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
        public async Task<IActionResult> DeleteUserAsync(Guid Id)
        {
            ControllerResponse response = new();
            if (_userRepo is not null)
            {
                response = await _userRepo.DeleteUserAsync(Id);
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
        public async Task<IActionResult> InsertUserAsync(User User)
        {
            ControllerResponse response = new();
            if (_userRepo is not null)
            {
                response = await _userRepo.InsertUserAsync(User);
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
