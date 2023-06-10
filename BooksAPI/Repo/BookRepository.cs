using BooksAPI.Model;
using BooksAPI.Utilities;
using Dapper;
using System.Data;
using System.Data.SqlTypes;

namespace BooksAPI.Repo
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _dbConnection;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        public BookRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<BookApiResponse> GetStortedBooksAsync()
        {
            BookApiResponse BookApiResponse = new BookApiResponse();
            try
            {
                using (var connection = _dbConnection)
                {
                    //BookApiResponse.Books = connection.Query<Book>(SQLStrings.GetStortedBooks).ToList();
                    BookApiResponse.Books = connection.Query<Book>("GetStortedBooks", commandType: CommandType.StoredProcedure).ToList();
                }
                if (BookApiResponse.Books != null && BookApiResponse.Books.Count > 0)
                {
                    BookApiResponse.ApiCallStatus = true;
                }
            }catch (Exception ex)
            {
                BookApiResponse.ApiCallStatus = false;
                BookApiResponse.ErrorMessage = "Internal Server Error";
            }
            return BookApiResponse;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<BookApiResponse> GetBooksSortedByAuthorAsync()
        {
            BookApiResponse BookApiResponse = new BookApiResponse();
            try
            {
                using (var connection = _dbConnection)
                {
                    //BookApiResponse.Books = connection.Query<Book>(SQLStrings.GetBooksSortedByAuthor).ToList();
                    BookApiResponse.Books = connection.Query<Book>("GetBooksSortedByAuthor", commandType: CommandType.StoredProcedure).ToList();
                }
                if (BookApiResponse.Books != null && BookApiResponse.Books.Count > 0)
                {
                    BookApiResponse.ApiCallStatus = true;
                }
            }catch(Exception ex)
            {
                BookApiResponse.ApiCallStatus = false;
                BookApiResponse.ErrorMessage = "Internal Server Error";
            }
            return BookApiResponse;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<BookApiResponse> GetTotalPriceOfBooksAsync()
        {
            BookApiResponse BookApiResponse = new BookApiResponse();
            try
            {
                using (var connection = _dbConnection)
                {
                    BookApiResponse.TotalPrice = connection.Query<decimal>(SQLStrings.GetTotalPriceOfBooks).FirstOrDefault();
                }
                if (BookApiResponse.TotalPrice != null && BookApiResponse.TotalPrice > 0)
                {
                    BookApiResponse.ApiCallStatus = true;
                }
            }catch(Exception ex)
            {
                BookApiResponse.ApiCallStatus = false;
                BookApiResponse.ErrorMessage = "Internal Server Error";
            }
            return BookApiResponse;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public async Task<BookApiResponse> SaveBooksAsync(List<Book> books)
        {
            BookApiResponse BookApiResponse = new BookApiResponse();
            try
            {
                using (var connection = _dbConnection)
                {
                    if (books.Count > 0)
                    {
                        int rowsAffected = connection.Execute(SQLStrings.SaveBooks, books);
                        if (rowsAffected == books.Count)
                        {
                            BookApiResponse.ApiCallStatus = true;
                            BookApiResponse.SuccessMessage = "All records saved successfully";
                        }
                        else if (rowsAffected < books.Count)
                        {
                            BookApiResponse.ApiCallStatus = true;
                            BookApiResponse.SuccessMessage = "Failed to save all records";
                        }
                        else
                        {
                            BookApiResponse.ApiCallStatus = false;
                            BookApiResponse.SuccessMessage = "Failed to save records";
                        }
                    }
                    else
                    {
                        BookApiResponse.ApiCallStatus = false;
                        BookApiResponse.SuccessMessage = "No record found";
                    }
                }               
            }
            catch (Exception ex)
            {
                BookApiResponse.ApiCallStatus = false;
                BookApiResponse.ErrorMessage = "Internal Server Error";
            }
            return BookApiResponse;
        }
    }
}