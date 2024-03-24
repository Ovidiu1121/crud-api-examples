using AnimalCrudApi.Animals.Model;

namespace AnimalCrudApi.Animals.Repository.interfaces
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal> GetByNameAsync(string name);
        Task<Animal> GetByIdAsync(int id);

    }
}
