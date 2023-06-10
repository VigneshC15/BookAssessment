using BooksAPI.Model;
using BooksAPI.Repo;

namespace BooksAPI.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookRepository"></param>
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<BookApiResponse> GetStortedBooksAsync()
        {
           return await _bookRepository.GetStortedBooksAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<BookApiResponse> GetBooksSortedByAuthorAsync()
        {
            return await _bookRepository.GetBooksSortedByAuthorAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<BookApiResponse> GetTotalPriceOfBooksAsync()
        {
            return await _bookRepository.GetTotalPriceOfBooksAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public async Task<BookApiResponse> SaveBooksAsync(List<Book> books)
        {
            return await _bookRepository.SaveBooksAsync(books);
        }
    }
}
