using Backend.Core;
using Backend.Core.Models;
using Backend.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Contact> CreateMusic(Contact newContact)
        {
            await _unitOfWork.Contacts.AddAsync(newContact);
            await _unitOfWork.CommitAsync();
            return newContact;
        }

        public async Task DeleteContact(Contact contact)
        {
            _unitOfWork.Contacts.Remove(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllWithReservations()
        {
            return await _unitOfWork.Contacts.GetAllWithReservationsAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _unitOfWork.Contacts.GetByIdAsync(id);
        }

        public async Task UpdateContact(Contact contactToBeUpdated, Contact contact)
        {
            contactToBeUpdated.Name = contact.Name;
            contactToBeUpdated.PhoneNumber = contact.PhoneNumber;
            contactToBeUpdated.BirthDate = contact.BirthDate;
            contactToBeUpdated.contactType = contact.contactType;
            await _unitOfWork.CommitAsync();
        }
    }
}
