using StudentCrudApi.Students.Model;

namespace StudentCrudApi.Students.Repository.interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByNameAsync(string name);
        Task<Student> GetByIdAsync(int id);
    }
}
