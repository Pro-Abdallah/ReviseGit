namespace librarymange.Models.Entites
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public DateTime MemberShipDate {  get; set; }
        public List<BookRecord> Records { get; set; }

    }
}
