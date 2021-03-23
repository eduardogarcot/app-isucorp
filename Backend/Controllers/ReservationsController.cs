using Backend.Core.Models;
using Backend.Core.Services;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            this._reservationService = reservationService;
        }

        // GET: api/reservations
        [HttpGet]
        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _reservationService.GetAllReservations();
        }

        // GET api/reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var item = await _reservationService.GetReservationById(id);
            if (item == null) return NotFound();
            return item;
        }

        // POST api/reservations
        [HttpPost]
        public async Task<ActionResult> PostReservation(Reservation reservation)
        {
            var newReservation = await _reservationService.CreateReservation(reservation);
            if (newReservation == null) return BadRequest();
            return CreatedAtAction(nameof(GetReservationById), new { id = reservation.ReservationId }, reservation);
        }

        // PUT api/reservations/:id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReservation(int id, Reservation reservation)
        {
            var item = await _reservationService.GetReservationById(id);
            if (item == null) return NotFound();
            await _reservationService.UpdateReservation(item, reservation);
            return NoContent();
        }

        // DELETE api/reservations/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var reservationToDelete = await _reservationService.GetReservationById(id);
            if (reservationToDelete == null) return NotFound();
            await _reservationService.DeleteReservation(reservationToDelete);
            return NoContent();
        }
    }
}
