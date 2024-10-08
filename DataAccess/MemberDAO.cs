using AutoMapper;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MemberDAO(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            var members = await _context.Members.ToListAsync();
            return _mapper.Map<IEnumerable<Member>>(members);
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            return _mapper.Map<Member>(member);
        }

        public async Task CreateMemberAsync(MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMemberAsync(int id, MemberDto memberDto)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }
            _mapper.Map(memberDto, member);
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
    }
}
