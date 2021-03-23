using Backend.Core;
using Backend.Core.Repositories;
using Backend.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackendDbContext _context;
        private ContactRepository _contactRepository;
        private ReservationRepository _reservationRepository;

        public UnitOfWork(BackendDbContext context)
        {
            this._context = context;
        }

        public IContactRepository Contacts => _contactRepository = _contactRepository ?? new ContactRepository(_context);

        public IReservationRepository Reservations => _reservationRepository = _reservationRepository ?? new ReservationRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
