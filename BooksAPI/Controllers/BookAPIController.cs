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
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="bookService"></param>
        public BookAPIController(IBookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        ///     Sort book list by Publisher, Author (last, first), then title
        /// </summary>
        /// <returns>return a sorted list of these by Publisher, Author (last, first), then title</returns>
        [HttpGet("sorted")]
        public async Task<BookApiResponse> GetStortedBooksAsync()
        {
            return await _bookService.GetStortedBooksAsync();
        }
        /// <summary>
        ///     Sort book list by Author (last, first) then title
        /// </summary>
        /// <returns>return a sorted list by Author (last, first) then title</returns>
        [HttpGet("sortByAuthor")]
        public async Task<BookApiResponse> GetBooksSortedByAuthorAsync()
        {
            return await _bookService.GetBooksSortedByAuthorAsync();
        }
        /// <summary>
        ///     Total Price of all books
        /// </summary>
        /// <returns>return the total price of all books</returns>
        [HttpGet("totalPrice")]
        public async Task <BookApiResponse> GetTotalPriceOfBooksAsync()
        {
            return await _bookService.GetTotalPriceOfBooksAsync();
        }
        /// <summary>
        ///     Save the entire list of books
        /// </summary>
        /// <param name="books"></param>
        /// <returns>to save the entire list of books</returns>
        [HttpPost("saveBooks")]
        public async Task<BookApiResponse> SaveBooksAsync([FromBody]List<Book> books)
        {
            return await _bookService.SaveBooksAsync(books);
        }

    }
}
