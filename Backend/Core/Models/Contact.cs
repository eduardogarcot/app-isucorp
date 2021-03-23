using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models
{
    public class Contact
    {
        public Contact()
        {
            Reservations = new List<Reservation>();
        }
        [Key]
        public int ContactId { get; set; }
        
        public int contactType { get; set; }
        public long PhoneNumber{ get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        
        public IList<Reservation> Reservations { get; set; }
    }
}
