﻿using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public StudentRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student?> GetBy(Guid id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Student>> GetAll()
        {
            int count = _dbContext.Students.Count();
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<ControllerResponse> UpdateStudentAsync(Student student)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(student).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(StudentRepo)} osztály, {nameof(UpdateStudentAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{student} frissítése nem sikerült!");
            }
            return response;
        }

        public async Task<ControllerResponse> DeleteStudentAsync(Guid Id)
        {
            ControllerResponse response = new ControllerResponse();
            Student? studentToDelete = await GetBy(Id);
            if (studentToDelete != null || studentToDelete == default)
            {
                response.AppendNewError($"{Id} idevel rendelkezo Student nem talalható!");
                response.AppendNewError("Item törlése nem sikerült!");
            }
            else
            {
                _dbContext.ChangeTracker?.Clear();
                _dbContext.Entry(parentToDelete).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            return response;
        }

        public async Task<ControllerResponse> InsertStudentAsyn(Parent parent)
        {
            try
            {
                _dbcontext.add(parent);
                await _dbContext.SaveChangesAsync()
                    }
            catch
            {
                ControllerResponse response = new ControllerResponse();
                response.AppendNewError($"{parent.Name} nem hozzaadható!");
                response.AppendNewError("A hozzáadás nem lehetséges!")
            }
        }
    }
}
