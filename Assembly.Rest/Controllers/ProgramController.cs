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
    public class ProgramController : ControllerBase
    {
        private readonly ProgramManager _programManager;

        public ProgramController(ProgramManager programManager)
        {
            _programManager = programManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddProgram([FromBody] ProgramInputDto program)
        {
            try
            {
                await _programManager.AddProgram(ProgramMapper.MapProgramToDomain(program));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ProgramOutputDto>>> GetAllPrograms()
        {
            try
            {
                var programs = await _programManager.GetAllPrograms();
                return Ok(programs.Select((p) => ProgramMapper.MapProgramToOutputDto(p)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{programCode}")]
        public async Task<IActionResult> GetProgram(string programCode)
        {
            try
            {
                return Ok(ProgramMapper.MapProgramToOutputDto(await _programManager.GetProgram(programCode)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgram([FromBody] ProgramDomain program)
        {
            try
            {
                await _programManager.UpdateProgram(program);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
