using librarymange.Models;
using librarymange.Models.Entites;
using librarymange.Repo.Repos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace librarymange.Repo.Implemetaion
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext dbcon;
        public BookRepo(AppDbContext dbcon)
        {
            this.dbcon = dbcon;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var booklist = await dbcon.Books.ToListAsync();
            return booklist;
        }

        public async Task Create(Book book)
        {
            await dbcon.Books.AddAsync(book);
            await dbcon.SaveChangesAsync();
        }
        public async Task Edit(Book book)
        {
            var searchbook = await dbcon.Books.FindAsync(book.BookID);
            if (searchbook != null)
            {
                searchbook.Author = book.Author;
                searchbook.Title = book.Title;
                searchbook.Genre = book.Genre;
                dbcon.Books.Update(searchbook);
                await dbcon.SaveChangesAsync();
            }
        }
        public async Task Delete(Book book)
        {
            var existingBook = await dbcon.Books.FirstOrDefaultAsync(f => f.BookID == book.BookID);
            if (existingBook != null)
            {
                dbcon.Books.Remove(existingBook);
                await dbcon.SaveChangesAsync();
            }
        }


        public async Task<Book> GetById(int id)
        {
            var searchbook = await dbcon.Books.FirstOrDefaultAsync(book => book.BookID == id);
            return searchbook;
        }

        public async Task<Book> Details(int id)
        {
            var BookDetials = await dbcon.Books.FirstOrDefaultAsync(book => book.BookID == id);
            return BookDetials;
        }
    }
}
