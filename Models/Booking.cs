using System;
using System.ComponentModel.DataAnnotations;

namespace TrainBookingSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TrainId { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }
    }
}
