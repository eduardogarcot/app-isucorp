using Backend.Core.Models;
using Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence.Repositories
{
    public class ReservationRepository : Repository<Reservation> , IReservationRepository
    {
        public ReservationRepository(BackendDbContext context)
            : base(context)
        { }

        private BackendDbContext BackendDbContext
        { 
            get { return Context as BackendDbContext; } 
        }

        public async Task<Reservation> GetWithContactByIdAsync(int id)
        {
            return await BackendDbContext.Reservations
                .Include(r => r.Contact)
                .SingleOrDefaultAsync(r => r.ContactId == id);
        }
    }
}
