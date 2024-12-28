using librarymange.Models.Entites;

namespace librarymange.ViewModel
{
    public class BookRecordVM
    {
        public int BookRecordVMID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}
