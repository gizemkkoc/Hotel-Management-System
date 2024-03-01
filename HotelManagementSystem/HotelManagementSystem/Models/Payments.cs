using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }
        public int ReservationID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        [StringLength(50)]
        public string PaymentType { get; set; }
    }
}
