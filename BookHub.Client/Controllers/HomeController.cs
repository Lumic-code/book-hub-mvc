using BookHub.Client.Models;
using BookHub.Client.Services;
using BookHub.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookHub.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooksAsync();

            var bookItems = new List<BookItemViewModel>();
            foreach (var book in books)
            {
                   bookItems.Add(new BookItemViewModel
                   {
                    Id = book.Id,
                    Name = book.Name,
                    ISBN = book.ISBN,
                    Author = book.Author,
                    TotalPages = book.TotalPages,
                    Portrait = book.Portrait
                });
            }
            return View(bookItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}