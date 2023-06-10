using BooksAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Repo
{
    public interface IBookRepository
    {
        Task<BookApiResponse> GetStortedBooksAsync();
        Task<BookApiResponse> GetBooksSortedByAuthorAsync();
        Task<BookApiResponse> GetTotalPriceOfBooksAsync();
        Task<BookApiResponse> SaveBooksAsync(List<Book> books);
    }
}
