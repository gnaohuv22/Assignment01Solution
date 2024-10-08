using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberAPI : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MemberAPI(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        //GET: api/Member/GetAllMembers
        [HttpGet("GetAllMembers")]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllMembers()
        {
            var members = await _memberRepository.GetAllMembersAsync();
            return Ok(members);
        }

        //GET: api/Member/GetMemberById/{id}
        [HttpGet("GetMemberById/{id}")]
        public async Task<ActionResult<Member>> GetMemberById(int id)
        {
            var member = await _memberRepository.GetMemberByIdAsync(id);
            return Ok(member);
        }

        //POST: api/Member/AddMember
        [HttpPost("AddMember")]
        public async Task<ActionResult<Member>> AddMember(MemberDto memberDto)
        {
            await _memberRepository.AddMemberAsync(memberDto);
            return CreatedAtAction(nameof(GetMemberById), new { id = memberDto.MemberId }, memberDto);
        }

        //PUT: api/Member/UpdateMember/{id}
        [HttpPut("UpdateMember/{id}")]
        public async Task<ActionResult<Member>> UpdateMember(int id, MemberDto memberDto)
        {
            await _memberRepository.UpdateMemberAsync(id, memberDto);
            return NoContent();
        }

        //DELETE: api/Member/DeleteMember/{id}
        [HttpDelete("DeleteMember/{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            await _memberRepository.DeleteMemberAsync(id);
            return NoContent();
        }
    }
}
