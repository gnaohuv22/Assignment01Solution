using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(int id);
        Task AddMemberAsync(MemberDto memberDto);
        Task UpdateMemberAsync(int id, MemberDto memberDto);
        Task DeleteMemberAsync(int id);
    }
}
