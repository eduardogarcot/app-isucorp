using System;
using System.Threading.Tasks;
using Backend.Core.Repositories;

namespace Backend.Core
{
    interface IUnitOfWork : IDisposable
    {
        IContactRepository Contacts { get; }
        IReservationRepository Reservations { get; }
        Task<int> CommitAsync();
    }
}
