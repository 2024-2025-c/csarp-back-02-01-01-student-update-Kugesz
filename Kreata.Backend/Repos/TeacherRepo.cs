
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

    public Task UpdateTeacherAsync(Teacher teacher)
    {
        throw new NotImplementedException();
    }
}