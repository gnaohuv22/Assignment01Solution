using BusinessObject;
using DataAccess;

namespace Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberDAO _memberDAO;

        public MemberRepository(MemberDAO memberDAO)
        {
            _memberDAO = memberDAO;
        }
        public async Task AddMemberAsync(MemberDto memberDto)
        {
            await _memberDAO.CreateMemberAsync(memberDto);
        }

        public async Task DeleteMemberAsync(int id)
        {
            await _memberDAO.DeleteMemberAsync(id);
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _memberDAO.GetAllMembersAsync();
        }

        public async Task<Member> GetMemberByEmail(string email)
        {
            return await _memberDAO.GetMemberByEmail(email);
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _memberDAO.GetMemberByIdAsync(id);
        }

        public async Task UpdateMemberAsync(int id, MemberDto memberDto)
        {
            await _memberDAO.UpdateMemberAsync(id, memberDto);
        }
    }
}
