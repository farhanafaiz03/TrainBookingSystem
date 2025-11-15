using System.ComponentModel.DataAnnotations;

namespace TrainBookingSystem.Models
{
    public class Train
    {
        public int TrainId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? DepartureCity { get; set; }

        [Required]
        public string? ArrivalCity { get; set; }

        [Required]
        public string? DepartureTime { get; set; }

        [Required]
        public string? ArrivalTime { get; set; }

        [Range(0, 500)]
        public int SeatsAvailable { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }
    }
}
