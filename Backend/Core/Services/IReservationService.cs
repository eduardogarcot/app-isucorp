using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Core.Models;

namespace Backend.Core.Services
{
    interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> GetReservationById(int id);
        Task<Reservation> GetWithContactById(int id);
        Task<Reservation> CreateReservation(Reservation newReservation);
        Task UpdateReservation(Reservation reservationToBeUpdated, Reservation reservation);
        Task DeleteReservation(Reservation reservation);
    }
}
