using Assembly.Domain.Managers;
using Assembly.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationManager _manager;
        private readonly ILogger _logger;

        public ReservationController(ReservationManager manager, ILogger<ReservationController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDomain>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Fetching reservations");
                return await _manager.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDomain>> GetReservation(int id)
        {
            try
            {
                _logger.LogInformation("Fetching reservation");
                return await _manager.GetReservationById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
