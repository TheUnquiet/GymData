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
    public class ReservationController : ControllerBase
    {
        private readonly ReservationManager _reservationManager;
        private readonly EquipmentManager _equipmentManager;
        private readonly TimeSlotManager _timeSlotManager;
        private readonly MemberManager _memberManager;
        private readonly ILogger _logger;

        public ReservationController(ReservationManager manager, EquipmentManager equipmentManager, MemberManager memberManager, TimeSlotManager timeSlotManager,  ILogger<ReservationController> logger)
        {
            _reservationManager = manager;
            _equipmentManager = equipmentManager;
            _memberManager = memberManager;
            _timeSlotManager = timeSlotManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDomain>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Fetching reservations");
                return await _reservationManager.GetAll();
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
                var r = await _reservationManager.GetReservationById(id);

                if (r != null) return Ok(r);

                else return NotFound("Reservation not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] ReservationInputDto reservationInputDto)
        {
            try
            {
                var equipment = await _equipmentManager.GetEquipmentById(reservationInputDto.EquipmentId);
                var member = await _memberManager.GetMemberById(reservationInputDto.MemberId);
                var timeslot = await _timeSlotManager.GetTimeSlot(reservationInputDto.TimeSlotId);

                var reservation = new ReservationDomain(
                    reservationInputDto.Date,
                    equipment,
                    member,
                    timeslot);

                //* Save to db
                await _reservationManager.AddReservation(reservation);

                return CreatedAtAction(nameof(GetReservation), new { Id = reservation.ReservationId }, reservation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                var reservation = await _reservationManager.GetReservationById(id);

                if (reservation == null) return NotFound("Reservation not found");

                else _reservationManager.DeleteReservation(reservation);

                return Ok($"Reservation {reservation.ReservationId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
