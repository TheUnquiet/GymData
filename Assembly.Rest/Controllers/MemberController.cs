using Assembly.Domain.Managers;
using Assembly.Domain.Models;
using Assembly.Rest.Dto.Input;
using Assembly.Rest.Dto.Output;
using Assembly.Rest.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberManager _manager;
        private readonly ILogger _logger;

        public MemberController(MemberManager manager, ILogger<MemberController> logger)
        {
            this._manager = manager;
            this._logger = logger;

        }

        [HttpGet]
        public async Task<ActionResult<List<MemberOutputDto>>> GetMembers()
        {
            try
            {
                _logger.LogInformation("Fetching members");

                var members = await _manager.GetMembers();

                return Ok(members.Select((m) => MemberMapper.MapToOutputDto(m)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberOutputDto>> GetMemberById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching member {id}");

                var member = await _manager.GetMemberById(id);

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
        public async Task<ActionResult> PostMember([FromBody]MemberInputDto memberDto)
        {
            try
            {
                var memeber = MemberMapper.MapFromInputDto(memberDto);

                _logger.LogInformation("Saving member");

                //* Save to db
                await _manager.AddMember(memeber);

                return CreatedAtAction(nameof(GetMemberById), new { id = memeber.Id }, memeber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody]MemberInputDto memberInputDto)
        {
            try
            {
                var member = await _manager.GetMemberById(id);

                _manager.UpdateMember(MemberMapper.MapFromInputDto(memberInputDto));

                return CreatedAtAction(nameof(GetMemberById), new { id = member.Id }, member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                var member = await _manager.GetMemberById(id);

                _manager.DeleteMember(id);

                return CreatedAtAction(nameof(GetMemberById), new { id = member.Id }, member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
