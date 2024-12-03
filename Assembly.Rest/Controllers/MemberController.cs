using Assembly.Domain.Managers;
using Assembly.Domain.Models;
using Assembly.Rest.Dto.Input;
using Assembly.Rest.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private MemberManager manager;

        public MemberController(MemberManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<List<MemberDomain>>> GetMembers()
        {
            try
            {
                var members = await manager.GetMembers();
                return Ok(members);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDomain>> GetMemberById(int id)
        {
            try
            {
                var member = await manager.GetMember(id);
                if (member == null)
                {
                    return NotFound();
                }

                return Ok(MemberMapper.MapToOutputDto(member));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostMember(MemberInputDto memberDto)
        {
            try
            {
                var memeber = MemberMapper.MapFromInputDto(memberDto);

                //* Save to db
                await manager.AddMember(memeber);

                return CreatedAtAction(nameof(GetMemberById), new { id = memeber.Id }, memeber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
