using librarymange.Models.Entites;

namespace librarymange.Repo.Repos
{
    public interface IMemberRepo
    {
        public Task<IEnumerable<Member>> GetAll();
        public Task Create(Member member);
        public Task Update(Member member);
        public Task<Member> GetMemberID(int id);
        public Task Delete(Member member);
        public Task<Member> Details(int id);
    }
}
