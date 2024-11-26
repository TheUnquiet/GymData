using Assembly.Domain.Managers;
using Assembly.Domain.Models;
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
                return Ok(await manager.GetMembers());
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

                return Ok(member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
