using BooksAPI.Model;
using BooksAPI.Repo;
using BooksAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookAPIController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("sorted")]
        public async Task<BookApiResponse> GetStortedBooksAsync()
        {
            return await _bookService.GetStortedBooksAsync();
        }

        [HttpGet("sortByAuthor")]
        public async Task<BookApiResponse> GetBooksSortedByAuthorAsync()
        {
            return await _bookService.GetBooksSortedByAuthorAsync();
        }

        [HttpGet("totalPrice")]
        public async Task <BookApiResponse> GetTotalPriceOfBooksAsync()
        {
            return await _bookService.GetTotalPriceOfBooksAsync();
        }

        [HttpPost("saveBooks")]
        public async Task<BookApiResponse> SaveBooksAsync([FromBody]List<Book> books)
        {
            return await _bookService.SaveBooksAsync(books);
        }

    }
}
