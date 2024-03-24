using UserCrudApi.Users.Model;

namespace UserCrudApi.Users.Repository.interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByNameAsync(string name);

    }
}
