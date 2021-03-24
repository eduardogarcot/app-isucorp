using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllWithReservations();
        Task<IEnumerable<Contact>> GetAllReservations();
        Task<Contact> GetContactById(int id);
        Task<Contact> CreateContact(Contact newContact);
        Task<Contact> UpdateContact(Contact contactToBeUpdated, Contact contact);
        Task DeleteContact(Contact contact);
    }
}
