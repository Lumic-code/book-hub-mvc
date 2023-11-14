using BookHub.API.Data.Entities;

namespace BookHub.API.Data.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(string id);
        Task<Book> AddBookAsync(Book enity);
        Task<Book> UpdateBookAsync(Book enity);
        Task<bool> DeleteBookAsync(Book enity);
        IEnumerable<Book> Paginate(IEnumerable<Book> books, int page, int pageSize);
    }
}
