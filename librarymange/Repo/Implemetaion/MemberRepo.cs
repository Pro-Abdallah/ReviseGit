using librarymange.Models;
using librarymange.Models.Entites;
using librarymange.Repo.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace librarymange.Repo.Implemetaion
{
    public class MemberRepo : IMemberRepo
    {
        private readonly AppDbContext dbcon;
        public MemberRepo(AppDbContext dbcon)
        {
            this.dbcon = dbcon;
        }

        public async Task Create(Member member)
        {
            await dbcon.Members.AddAsync(member);
            await dbcon.SaveChangesAsync();
        }

        public async Task Delete(Member member)
        {
            var getmeme = await dbcon.Members.FirstOrDefaultAsync(m => m.MemberID == member.MemberID);
            if (getmeme != null)
            {
                dbcon.Members.Remove(getmeme);
                await dbcon.SaveChangesAsync();
            }
        }

        public async Task<Member> Details(int id)
        {
            var deimem = await dbcon.Members.FirstOrDefaultAsync(fi => fi.MemberID == id);
            if (deimem == null)
            {
                throw new KeyNotFoundException($"Member with ID {id} not found.");
            }
            return deimem;
        }



        public async Task<IEnumerable<Member>> GetAll()
        {
            var memberlist = await dbcon.Members.ToListAsync();
            return memberlist;
        }

        public async Task<Member> GetMemberID(int id)
        {
            var getid = await dbcon.Members.FirstOrDefaultAsync(s => s.MemberID == id);
            return getid;
        }

        public async Task Update(Member member)
        {
            if (member is not null)
            {
                dbcon.Members.Update(member);
                await dbcon.SaveChangesAsync();
            }
        }
    }
}
