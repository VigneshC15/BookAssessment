namespace BooksAPI.Utilities
{
    public static class SQLStrings
    {
        public const string GetStortedBooks = "SELECT * FROM tbl_Books where IsActive=1 and IsDeleted=0 order by Publisher,CONCAT(AuthorLastName, ' ', AuthorFirstName),Title";
        public const string GetBooksSortedByAuthor = "SELECT * FROM tbl_Books where IsActive=1 and IsDeleted=0 ORDER BY CONCAT(AuthorLastName, ' ', AuthorFirstName), Title";
        public const string GetTotalPriceOfBooks = "SELECT SUM(Price) FROM tbl_Books where IsActive=1 and IsDeleted=0 ";
        public const string SaveBooks = "INSERT INTO tbl_Books (Publisher, Title, AuthorLastName, AuthorFirstName, Price, IsActive, IsDeleted, CreatedDt, TitleContainer, Pages, PageRange, VolumeNo, IssueNo, URL, Language, Country) VALUES (@Publisher, @Title, @AuthorLastName, @AuthorFirstName, @Price, 1, 0, getdate(), @TitleContainer, @Pages, @PageRange, @VolumeNo, @IssueNo, @URL, @Language, @Country)";
    }
}
