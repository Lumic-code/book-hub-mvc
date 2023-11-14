using BookHub.Client.Models;

namespace BookHub.Client.Services
{
    public class BookService : BaseService, IBookService
    {

        public BookService(HttpClient client, IConfiguration config) : base(client, config)
        { }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var address = "/api/Book/get-all";
            var apiResponse = await this.MakeApiRequestAsync<IEnumerable<Book>>(address);

            if (apiResponse != null)
            {
                return apiResponse;
            }

            return null;
        }
    }
}
