using librarymange.Models.Entites;
using librarymange.Repo.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Razor;

namespace librarymange.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepo memberRepo;
        public MemberController(IMemberRepo memberRepo)
        {
            this.memberRepo = memberRepo;
        }
        public async Task<IActionResult> Index()
        {
            var memberlist = await memberRepo.GetAll();
            return View(memberlist);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            if (member is not null)
            {
                await memberRepo.Create(member);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id, Member member)
        {
            var getmembr = await memberRepo.GetMemberID(id);
            if (getmembr != null)
            {
                return View(getmembr);
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Member member)
        {
            if (member is not null)
            {
                await memberRepo.Update(member);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var getmem = await memberRepo.GetMemberID(id);
            if (getmem != null)
            {
                return View(getmem);
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Member member, int id)
        {
            var memberget = await memberRepo.GetMemberID(id);
            if (memberget is not null)
            {
                await memberRepo.Delete(memberget);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var detailsmem = await memberRepo.Details(id);
            if (detailsmem is not null)
            {
                return View(detailsmem);
            }
            return NoContent();
        }
    }
}
