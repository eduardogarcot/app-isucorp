using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Core.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<Reservation> GetWithContactByIdAsync(int id);
    }
}
