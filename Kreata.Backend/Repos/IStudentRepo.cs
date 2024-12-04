using Kreata.Backend.Datas.Entities;

namespace Kreata.Backend.Repos
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAll();
        Task<Student?> GetBy(Guid id);
        Task<ControllerResponse> UpdateStudentAsync(Student student);
        Task<ControllerResponse> DeleteItemAsync(Guid Id);
    }
}
