using Backend.Models;
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
        private readonly BackendDbContext _context;

        public ReservationsController(BackendDbContext context)
        {
            _context = context;
        }

        // GET: api/reservations
        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {
            return _context.Reservations;
        }

        // GET api/reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var item = await _context.Reservations.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        // POST api/reservations
        [HttpPost]
        public async Task<ActionResult> PostReservation(Reservation reservation)
        {
            var item = await _context.Reservations.FindAsync(reservation.ReservationId);
            var phoneNumber = await _context.Contacts.FindAsync(reservation.ContactId);
            if (item != null
                || phoneNumber == null
                || (reservation.Rate < 0 || reservation.Rate > 5))
                return BadRequest();
            reservation.Contact = phoneNumber;
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReservationById), new { id = reservation.ReservationId }, reservation);
        }

        // PUT api/reservations/:id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReservation(int id, Reservation reservation)
        {
            var item = await _context.Reservations.FindAsync(id);
            var phoneNumber = await _context.Contacts.FindAsync(reservation.ContactId);
            if (item == null) return NotFound();
            if (id != reservation.ReservationId
                || phoneNumber == null
                || (reservation.Rate < 0 || reservation.Rate > 5))
                return BadRequest();
            reservation.Contact = phoneNumber;
            _context.Entry(item).State = EntityState.Detached;
            _context.Entry(reservation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/reservations/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var item = await _context.Reservations.FindAsync(id);
            if (item == null) return NotFound();
            _context.Reservations.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
