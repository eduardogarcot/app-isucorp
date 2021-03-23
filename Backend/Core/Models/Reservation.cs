using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public DateTime CratedDate { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool isFavorite { get; set; }
        public int Rate { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}