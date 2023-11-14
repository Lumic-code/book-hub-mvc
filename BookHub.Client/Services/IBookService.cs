using BookHub.Client.Models;

namespace BookHub.Client.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}
