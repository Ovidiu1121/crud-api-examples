using CountryCrduApi.Countries.Model;

namespace CountryCrduApi.Countries.Repository.interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> GetByNameAsync(string name);
        Task<Country> GetByPopulationAsync(int population);
    }
}
