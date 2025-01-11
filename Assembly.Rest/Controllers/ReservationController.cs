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
        public async Task<ActionResult<ReservationOutputDto>> GetReservation(int id)
        {
            try
            {
                _logger.LogInformation("Fetching reservation");
                var r = await _reservationManager.GetReservationById(id);

                if (r != null) return Ok(ReservationMapper.MapToOutputDto(r));

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
                // Retrieve the related entities from their managers
                var equipmentList = new List<EquipmentDomain>();
                foreach (var equipmentId in reservationInputDto.EquipmentIds)
                {
                    var equipment = await _equipmentManager.GetEquipmentById(equipmentId);
                    equipmentList.Add(equipment);
                }

                var member = await _memberManager.GetMemberById(reservationInputDto.MemberId);

                var timeSlotList = new List<TimeSlotDomain>();
                foreach (var timeSlotId in reservationInputDto.TimeSlotIds)
                {
                    var timeSlot = await _timeSlotManager.GetTimeSlot(timeSlotId);
                    timeSlotList.Add(timeSlot);
                }

                // Create the ReservationDomain with the multiple equipment and time slots
                var reservationDomain = new ReservationDomain(
                    reservationInputDto.Date,
                    member,
                    timeSlotList,
                    equipmentList);

                //* Save the reservation to the database
                await _reservationManager.AddReservation(reservationDomain);

                return CreatedAtAction(nameof(GetReservation), new { Id = reservationDomain.ReservationId }, reservationDomain);
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
