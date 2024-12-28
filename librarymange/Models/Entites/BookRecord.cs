namespace librarymange.Models.Entites
{
    public class BookRecord
    {
        public int BookRecordID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate  {get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
