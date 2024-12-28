using librarymange.Models.Entites;
using librarymange.ViewModel;

namespace librarymange.Repo.Repos
{
    public interface IBookRecordRepo
    {
        public Task<IEnumerable<BookRecord>> GetAllRecords();
        public Task Create(BookRecord bookRecord);
        public Task Edit(BookRecordVM bookvm, int id);
        public Task<BookRecord> GetRecordID(int id);
        public Task Delete(int id);
        public Task<BookRecord> Details(int id);
    }
}
