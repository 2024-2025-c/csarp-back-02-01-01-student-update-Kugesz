
using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.EntityFrameworkCore;

public class TeacherRepo : ITeacherRepo
{
    private readonly KretaInMemoryContext _dbContext;

    public TeacherRepo(KretaInMemoryContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Teacher>> GetAll()
    {
        return await _dbContext.Teachers.ToListAsync();
    }

    public async Task<Teacher?> GetBy(Guid id)
    {
        return await _dbContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<ControllerResponse> UpdateTeacherAsync(Teacher teacher)
    {
        ControllerResponse response = new ControllerResponse();
        _dbContext.ChangeTracker.Clear();
        _dbContext.Entry(teacher).State = EntityState.Modified;
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            response.AppendNewError(e.Message);
            response.AppendNewError($"{nameof(TeacherRepo)} osztály, {nameof(UpdateTeacherAsync)} metódusban hiba keletkezett");
            response.AppendNewError($"{teacher} frissítése nem sikerült!");
        }
        return response;
    }

    public async Task<ControllerResponse> DeleteTeacherAsync(Guid Id)
    {
        ControllerResponse response = new ControllerResponse();
        Teachers? teacherToDelete = await GetBy(Id);
        if (teacherToDelete != null || teacherToDelete == default)
        {
            response.AppendNewError($"{Id} idevel rendelkezo Teacher nem talalható!");
            response.AppendNewError("Item törlése nem sikerült!");
        }
        else
        {
            _dbContext.ChangeTracker?.Clear();
            _dbContext.Entry(teacherToDelete).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
        return response;
    }

    public async Task<ControllerResponse> InsertTeacherAsyn(Teacher teacher)
    {
        try
        {
            _dbcontext.add(teacher);
            await _dbContext.SaveChangesAsync()
            }
        catch
        {
            ControllerResponse response = new ControllerResponse();
            response.AppendNewError($"{teacher.Name} nem hozzaadható!");
            response.AppendNewError("A hozzáadás nem lehetséges!")
            }
    }
}