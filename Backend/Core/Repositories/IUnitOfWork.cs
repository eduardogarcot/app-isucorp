using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Core.Repositories
{
    interface IUnitOfWork
    {
        IContactRepository Contacts { get; }
        IReservationRepository Reservations { get; }
        Task<int> CommitAsync();
    }
}
