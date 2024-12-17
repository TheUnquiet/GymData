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
    public class EquipmentController : ControllerBase
    {
        private readonly EquipmentManager _manager;
        private readonly ILogger _logger;

        public EquipmentController(EquipmentManager manager, ILogger<EquipmentController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<EquipmentOutputDto>>> GetAll()
        {
            try
            {
                var equipment = await _manager.GetAll();

                return Ok(equipment.Select(e => EquipmentMapper.MapToOutputDto(e)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentOutputDto>> GetEquipmentById(int id)
        {
            try
            {
                _logger.LogInformation("Fetching equipment");

                var equipment = await _manager.GetEquipmentById(id);

                if (equipment == null)
                {
                    return NotFound("equipment not found");
                }

                return Ok(EquipmentMapper.MapToOutputDto(equipment));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipment([FromBody] EquipmentInputDto equipmentInpuDto)
        {
            try
            {
                var equipment = EquipmentMapper.MapFromInputDto(equipmentInpuDto);

                _logger.LogInformation("Saving equipment");
                await _manager.AddEquipment(equipment);
                

                return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.EquipmentId }, equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            try
            {
                await _manager.DeleteEquipment(id);

                return Ok("Equipment deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
