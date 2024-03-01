using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
    }
}
