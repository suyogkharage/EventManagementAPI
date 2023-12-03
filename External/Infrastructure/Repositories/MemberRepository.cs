using Domain.Abstractions;
using Domain.Entities;


namespace Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _appDbContext;

        
        public MemberRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Member?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var member = _appDbContext.Members.Where(x => x.MemberId == id).FirstOrDefault();

            if (member == null)
            {
                return null;
            }

            return member;
        }
    }
}
