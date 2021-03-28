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
        public async Task<Contact> CreateContact(Contact newContact)
        {
            var contactToAdd = await ValidateContactAsync(newContact);
            if (contactToAdd != null)
            {
                await _unitOfWork.Contacts.AddAsync(contactToAdd);
                await _unitOfWork.CommitAsync();
            }
            return contactToAdd;
        }

        public async Task DeleteContact(Contact contact)
        {
            _unitOfWork.Contacts.Remove(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllWithReservations()
        {
            return await _unitOfWork.Contacts.GetAllContactsAsync();
            // return await _unitOfWork.Contacts.GetAllWithReservationsAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllReservations()
        {
            return await _unitOfWork.Contacts.GetAllAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _unitOfWork.Contacts.GetByIdAsync(id);
        }

        public async Task<Contact> UpdateContact(Contact contactToBeUpdated, Contact contact)
        {
            var contactMatchedByPhoneNumber = (await _unitOfWork.Contacts.GetAllAsync()).FirstOrDefault(c => c.PhoneNumber == contact.PhoneNumber);
            if (contactMatchedByPhoneNumber != null && contact.PhoneNumber != contactToBeUpdated.PhoneNumber ) 
                return null; 
            contactToBeUpdated.Name = contact.Name;
            contactToBeUpdated.PhoneNumber = contact.PhoneNumber;
            contactToBeUpdated.BirthDate = contact.BirthDate;
            contactToBeUpdated.contactType = contact.contactType;
            await _unitOfWork.CommitAsync();
            return contactToBeUpdated;
        }

        public async Task<Contact> ValidateContactAsync(Contact contact)
        {
            var itemMatchedById = await _unitOfWork.Contacts.GetByIdAsync(contact.ContactId);
            var itemMatchedByPhoneNumber = (await _unitOfWork.Contacts.GetAllAsync()).FirstOrDefault((c => c.PhoneNumber == contact.PhoneNumber));
            if (itemMatchedById != null || itemMatchedByPhoneNumber!= null)
                return null;
            return contact;
        }
    }
}
