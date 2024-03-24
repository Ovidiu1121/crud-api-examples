using BookCrudApi.Books.Model;

namespace BookCrudApi.Books.Repository.interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> GetByTitleAsync(string title);
    }
}
