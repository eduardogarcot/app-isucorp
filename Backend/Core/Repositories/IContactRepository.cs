using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Core.Repositories
{
    interface IContactRepository: IRepository<Contact> 
    {
        Task<IEnumerable<Contact>> GetAllWithReservations();
    }
}
