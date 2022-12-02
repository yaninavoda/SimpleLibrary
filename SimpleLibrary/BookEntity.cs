namespace SimpleLibrary
{
    public class BookEntity : BaseEntity
    {
        public int LibraryId { get; set; }
        public int Year { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
