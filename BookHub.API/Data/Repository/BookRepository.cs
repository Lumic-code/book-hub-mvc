using BookHub.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookHub.API.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
           
        }
        public async Task<Book> AddBookAsync(Book enity)
        {
            await _context.Books.AddAsync(enity);
            await _context.SaveChangesAsync();
            return enity;
        }


        public async Task<bool> DeleteBookAsync(Book enity)
        {
            _context.Books.Remove(enity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Book> GetBookAsync(string id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                return book;
            }
            return null;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public IEnumerable<Book> Paginate(IEnumerable<Book> books, int page, int pageSize)
        {
            return books.Skip(page - 1 * pageSize).Take(pageSize);
        }

        public async Task<Book> UpdateBookAsync(Book enity)
        {
             _context.Books.Update(enity);
            await _context.SaveChangesAsync();
            return enity;
        }
    }
}
