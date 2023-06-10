using BooksAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Service
{
    public interface IBookService
    {
        Task<BookApiResponse> GetStortedBooksAsync();
        Task<BookApiResponse> GetBooksSortedByAuthorAsync();
        Task<BookApiResponse> GetTotalPriceOfBooksAsync();
        Task<BookApiResponse> SaveBooksAsync(List<Book> books);
    }
}
