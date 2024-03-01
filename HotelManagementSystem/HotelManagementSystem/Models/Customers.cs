using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(50)]  
      // Veya Fluent API kullanarak modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasMaxLength(100);
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
    }
}
