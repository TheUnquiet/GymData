using Assembly.Domain.Managers;
using Assembly.Domain.Models;
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
        public async Task<ActionResult<List<TimeSlotDomain>>> GetAll()
        {
            try
            {
                return await _manager.GetTimeSlots();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlotDomain>> GetTimeSlot(int id)
        {
            try
            {
                return await _manager.GetTimeSlot(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
