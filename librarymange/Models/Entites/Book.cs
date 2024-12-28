namespace librarymange.Models.Entites
{
    public class Book
    {
        public int BookID {  get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public List<BookRecord> Records { get; set; }
    }
}
