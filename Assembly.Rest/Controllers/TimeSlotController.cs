using Assembly.Domain.Managers;
using Assembly.Domain.Models;
using Assembly.Rest.Dto.Output;
using Assembly.Rest.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly TimeSlotManager _manager;

        public TimeSlotController(TimeSlotManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeSlotOutputDto>>> GetAll()
        {
            try
            {
                var timeSlots = await _manager.GetTimeSlots();
                return timeSlots.Select(t => TimeSlotMapper.MapToOuputDto(t)).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlotOutputDto>> GetTimeSlot(int id)
        {
            try
            {
                var timeSlot = await _manager.GetTimeSlot(id);
                return TimeSlotMapper.MapToOuputDto(timeSlot);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
