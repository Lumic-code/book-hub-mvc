using BookHub.API.Data.Entities;
using BookHub.API.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBooks(int page, int pageSize)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 10 ? 10 : pageSize;

            var books = await _bookRepository.GetBooksAsync();
            var paginatedBooks = _bookRepository.Paginate(books, page, pageSize);
            if (paginatedBooks != null && paginatedBooks.Any())
            {
                return Ok(paginatedBooks);
            }
            return NotFound("No records found for books");
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound($"No book found for id {id}");
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBook(Book book)
        {
            var newBook = await _bookRepository.AddBookAsync(book);
            if (newBook != null)
            {
                return Ok(newBook);
            }
            return BadRequest("Error adding book");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var updatedBook = await _bookRepository.UpdateBookAsync(book);
            if (updatedBook != null)
            {
                return Ok(updatedBook);
            }
            return BadRequest("Error updating book");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            if (book != null)
            {
                var deleted = await _bookRepository.DeleteBookAsync(book);
                if (deleted)
                {
                    return Ok("Book deleted successfully");
                }
                return BadRequest("Error deleting book");
            }
            return NotFound($"No book found for id {id}");
        }
    }
}
