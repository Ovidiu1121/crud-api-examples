using HotelCrudApi.Hotels.Model;

namespace HotelCrudApi.Hotels.Repository.interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int id);
        Task<Hotel> GetByNameAsync(string name);
    }
}
