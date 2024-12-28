using librarymange.Models.Entites;
using librarymange.Repo.Repos;
using Microsoft.AspNetCore.Mvc;

namespace librarymange.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepo bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }
        public async Task<IActionResult> Index()
        {
            var booklist = await bookRepo.GetAllBooks();
            return View(booklist);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (book is not null)
            {
                await bookRepo.Create(book);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var searchbook = await bookRepo.GetById(id);
            return View(searchbook);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (book is not null)
            {
                await bookRepo.Edit(book);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var searchbook = await bookRepo.GetById(id);
            return View(searchbook);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Book books, int id)
        {
            var book = await bookRepo.GetById(id);
            if (book != null)
            {
                await bookRepo.Delete(book);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Detials(int id)
        {
            var bookdetials = await bookRepo.Details(id);
            return View(bookdetials);
        }
    }
}
