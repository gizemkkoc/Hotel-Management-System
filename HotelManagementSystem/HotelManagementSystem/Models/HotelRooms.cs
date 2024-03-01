using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class HotelRooms
    {
        [Key]
        public int RoomId { get; set; }
        public decimal RoomNo { get; set; }
        [StringLength(50)]
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        [StringLength(50)]
        public string Status{ get; set; }
       
    }
}
