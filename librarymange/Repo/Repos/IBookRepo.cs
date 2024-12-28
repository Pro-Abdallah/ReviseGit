using librarymange.Models.Entites;

namespace librarymange.Repo.Repos
{
    public interface IBookRepo
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task Create(Book book);
        public Task Edit(Book book);
        public Task Delete(Book book);
        public Task<Book> GetById(int id);
        public Task<Book> Details(int id);
    }
}
