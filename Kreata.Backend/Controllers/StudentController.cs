﻿using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Student>? users = new();

            if (_studentRepo != null)
            {
                users = await _studentRepo.GetAll();
                return Ok(users);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Student? entity = new();
            if (_studentRepo is not null)
            {
                entity = await _studentRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateStudentAsync(Student entity)
        {
            ControllerResponse response = new();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.UpdateStudentAsync(entity);
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
        public async Task<IActionResult> DeleteStudentAsync(Guid Id)
        {
            ControllerResponse response = new();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.DeleteStudentAsync(Id);
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
        public async Task<IActionResult> InsertStudentAsync(Student student)
        {
            ControllerResponse response = new();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.InsertStudentAsync(student);
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
