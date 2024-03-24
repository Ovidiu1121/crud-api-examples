using CarCrudApi.Cars.Model;

namespace CarCrudApi.Cars.Repository.interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByBrandAsync(string brand);
    }
}
