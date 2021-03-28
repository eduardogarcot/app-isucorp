using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Core.Repositories;
using Backend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(BackendDbContext context) 
            :base (context)
        { }

        private BackendDbContext BackendDbContext
        {
            get { return Context as BackendDbContext; }
        }

        public async Task<IEnumerable<Contact>> GetAllWithReservationsAsync()
        {
            return await BackendDbContext.Contacts
                .Include( c => c.Reservations)
                .ToListAsync();
        }
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await BackendDbContext.Contacts.FromSqlInterpolated($"GetAllContacts").ToListAsync();
        }
    }
}
