using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        
        public long PhoneNumber{ get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        
        public ICollection<Reservation> ReservationsList { get; set; }
    }
}
