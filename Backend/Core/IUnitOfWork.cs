using System;
using System.Threading.Tasks;
using Backend.Core.Repositories;

namespace Backend.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository Contacts { get; }
        IReservationRepository Reservations { get; }
        Task<int> CommitAsync();
    }
}
