using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _memberRepository.GetMembers();

            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await _memberRepository.GetMemberById(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }
    }
}