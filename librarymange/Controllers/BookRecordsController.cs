using librarymange.Models.Entites;
using librarymange.Repo.Repos;
using librarymange.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace librarymange.Controllers
{
    public class BookRecordsController : Controller
    {
        private readonly IBookRecordRepo recordRepo;
        private readonly IBookRepo bookRepo;
        private readonly IMemberRepo memberRepo;
        public BookRecordsController(IBookRecordRepo recordRepo, IBookRepo bookRepo, IMemberRepo memberRepo)
        {
            this.recordRepo = recordRepo;
            this.bookRepo = bookRepo;
            this.memberRepo = memberRepo;
        }
        public async Task<IActionResult> Index()
        {
            var recordlist = await recordRepo.GetAllRecords();
            return View(recordlist);
        }
        public async Task<IActionResult> Create()
        {
            var booklist = await bookRepo.GetAllBooks();
            var memelist = await memberRepo.GetAll();
            BookRecordVM vm = new BookRecordVM()
            {
                Books = booklist,
                Members = memelist
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookRecord bookr)
        {
            if (bookr is not null)
            {
                await recordRepo.Create(bookr);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var getrec = await recordRepo.GetRecordID(id);
            var booklist = await bookRepo.GetAllBooks();
            var memelist = await memberRepo.GetAll();
            BookRecordVM vm = new BookRecordVM()
            {
                Books = booklist,
                BookID = getrec.BookID,
                BorrowDate = getrec.BorrowDate,
                ReturnDate = getrec.ReturnDate,
                Members = memelist,
                MemberID = getrec.MemberID
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookRecordVM bookr, int id)
        {
            await recordRepo.Edit(bookr, id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id, BookRecord bookRecord)
        {
            var getrec = await recordRepo.GetRecordID(id);
            return View(getrec);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
                await recordRepo.Delete(id);
                return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
           var det = await recordRepo.Details(id);
           return View(det);
        }
    }
}
