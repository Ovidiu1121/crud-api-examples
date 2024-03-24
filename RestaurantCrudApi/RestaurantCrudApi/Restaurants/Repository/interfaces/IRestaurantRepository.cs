using RestaurantCrudApi.Restaurants.Model;

namespace RestaurantCrudApi.Restaurants.Repository.interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant> GetByIdAsync(int id);
        Task<Restaurant> GetByLocationAsync(string location);
    }
}
