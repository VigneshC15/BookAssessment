using System.Security.Policy;

namespace BooksAPI.Model
{
    public class BookApiResponse
    {
        public bool ApiCallStatus { get; set; }
        public string SuccessMessage {get;set;}
        public string ErrorMessage { get; set; }
        public List<Book> Books { get; set; }
        public decimal TotalPrice { get; set; }       
    }
    public class Book
    {
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }
        public string TitleContainer { get; set; }
        public int Pages { get; set; }
        public string PageRange { get; set; }
        public int VolumeNo { get; set; }
        public int IssueNo { get; set; }
        public string URL { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string MLACitation
        {
            get
            {
                return $"{AuthorLastName}, {AuthorFirstName}. '{Title}' {TitleContainer}, {Publisher}, pp. {PageRange}.";
            }
        }
        public string ChicagoCitation
        {
            get
            {
                return $"{AuthorLastName}, {AuthorFirstName}. {Publisher}. '{Title}' {TitleContainer}, no. {VolumeNo}, ({IssueNo}): {PageRange}. {URL}.";
            }
        }
    }
}
