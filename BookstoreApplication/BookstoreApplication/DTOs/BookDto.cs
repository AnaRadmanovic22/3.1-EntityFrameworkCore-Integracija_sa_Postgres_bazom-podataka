namespace BookstoreApplication.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string AuthorFullName { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
        public int YearsSincePublished { get; set; }
    }
}
