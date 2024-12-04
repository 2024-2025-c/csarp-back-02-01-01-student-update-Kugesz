using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
        private IParentRepo _parentRepo;

        public ParentController(IParentRepo parentRepo)
        {
            _parentRepo = parentRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Parent? entity = new();
            if (_parentRepo is not null)
            {
                entity = await _parentRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Parent>? users = new();

            if (_parentRepo != null)
            {
                users = await _parentRepo.GetAll();
                return Ok(users);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateParentAsync(Parent entity)
        {
            ControllerResponse response = new();
            if (_parentRepo is not null)
            {
                response = await _parentRepo.UpdateParentAsync(entity);
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

        [HttpPut()]
        public async Task<ActionResult> UpdateParentAsync(Parent entity)
        {
            ControllerResponse response = new();
            if (_parentRepo is not null)
            {
                response = await _parentRepo.UpdateParentAsync(entity);
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
        public async Task<IActionResult> DeleteParentAsync(Guid Id)
        {
            ControllerResponse response = new();
            if (_parentRepo is not null)
            {
                response = await _parentRepo.DeleteParentAsync(Id);
                if (response.HasError)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response)
                }
            }
            response.ClearAndAddError("Az adat törlése nem lehetséges");
            return BadRequest(response);
        }
    }
}
