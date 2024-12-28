using librarymange.Models;
using librarymange.Models.Entites;
using librarymange.Repo.Repos;
using librarymange.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace librarymange.Repo.Implemetaion
{
    public class BookRecordRepo : IBookRecordRepo
    {
        private readonly AppDbContext dbcon;
        public BookRecordRepo(AppDbContext dbcon)
        {
            this.dbcon = dbcon;
        }

        public async Task Create(BookRecord bookRecord)
        {
            await dbcon.BookRecords.AddAsync(bookRecord);
            await dbcon.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var searchrec = await dbcon.BookRecords.FirstOrDefaultAsync(x => x.BookRecordID == id);
            if (searchrec != null)
            {
                dbcon.BookRecords.Remove(searchrec);
                await dbcon.SaveChangesAsync();
            }
        }

        public async Task<BookRecord> Details(int id)
        {
            return await dbcon.BookRecords.Include(b => b.Book).Include(m => m.Member).FirstOrDefaultAsync(x => x.BookRecordID == id);
        }

        public async Task Edit(BookRecordVM bookvm, int id)
        {
            var searchbook = await dbcon.BookRecords.FindAsync(id);
            if (bookvm is not null)
            {
                searchbook.BookID = bookvm.BookID;
                searchbook.BorrowDate = bookvm.BorrowDate;
                searchbook.ReturnDate = bookvm.ReturnDate;
                searchbook.MemberID = bookvm.MemberID;
                dbcon.BookRecords.Update(searchbook);
                await dbcon.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookRecord>> GetAllRecords()
        {
            return await dbcon.BookRecords.Include(b => b.Book).Include(m => m.Member).ToListAsync();
        }

        public async Task<BookRecord> GetRecordID(int id)
        {
            return await dbcon.BookRecords.Include(b => b.Book).Include(m => m.Member).FirstOrDefaultAsync(x => x.BookRecordID == id);
        }
        
    }
}
