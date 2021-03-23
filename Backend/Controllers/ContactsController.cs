using Backend.Core.Models;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly BackendDbContext _context;

        public ContactsController(BackendDbContext context)
        {
            _context = context;
        }

        // GET: api/contact
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _context.Contacts.ToListAsync();
        }

        // GET api/contact/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var item = await _context.Contacts.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        // POST api/contact
        [HttpPost]
        public async Task<ActionResult> PostContact(Contact contact)
        {
            var itemById = await _context.Contacts.FindAsync(contact.ContactId);
            var itemByPhone = await _context.Contacts.FirstOrDefaultAsync(c => c.PhoneNumber == contact.PhoneNumber);
            if ( itemByPhone != null
                || contact.Name == null
                || contact.PhoneNumber < 1000000)
                return BadRequest();
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContactById), new { id = contact.ContactId }, contact);
        }

        // PUT api/contact/:id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, Contact contact)
        {
            var item = await _context.Contacts.FindAsync(id);
            if (item == null) return NotFound();
            if (id != contact.PhoneNumber || contact.Name == null) return BadRequest();
            _context.Entry(item).State = EntityState.Detached;
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/contact/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var item = await _context.Contacts.FindAsync(id);
            if (item == null) return NotFound();
            _context.Contacts.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
