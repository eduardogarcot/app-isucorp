using Backend.Core;
using Backend.Core.Models;
using Backend.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Reservation> CreateReservation(Reservation newReservation)
        {
            var reservationToCreate = await ReservationValidation(newReservation);
            if (reservationToCreate != null)
            {
                await _unitOfWork.Reservations.AddAsync(reservationToCreate);
                await _unitOfWork.CommitAsync();
            }
            return reservationToCreate;
        }

        public async Task DeleteReservation(Reservation reservation)
        {
            _unitOfWork.Reservations.Remove(reservation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _unitOfWork.Reservations.GetAllAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _unitOfWork.Reservations.GetByIdAsync(id);
        }

        public async Task<Reservation> GetWithContactById(int id)
        {
            return await _unitOfWork.Reservations.GetWithContactByIdAsync(id);
        }

        public async Task UpdateReservation(Reservation reservationToBeUpdated, Reservation reservation)
        {
            reservationToBeUpdated.Description = reservation.Description;
            reservationToBeUpdated.isFavorite = reservation.isFavorite;
            reservationToBeUpdated.Rate = reservation.Rate;
            reservationToBeUpdated.ReservationDate = reservation.ReservationDate;
            reservationToBeUpdated.ContactId = reservation.ContactId;
            await _unitOfWork.CommitAsync();
        }

        public async Task<Reservation> ReservationValidation(Reservation reservation)
        {
            var reservationMatchedById = await _unitOfWork.Reservations.GetByIdAsync(reservation.ReservationId);
            var contactMatchedById = await _unitOfWork.Contacts.GetByIdAsync(reservation.ContactId);
            reservation.CratedDate = DateTime.Now;
            if (reservationMatchedById != null || contactMatchedById != null)
                return null;
            return reservation;
        }
    }
}
