using System.ComponentModel.DataAnnotations;

namespace InvSysMan.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }

        [Required]
        [MaxLength(100)]
        public required string ProductName { get; set; }

        public decimal PurchasedPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime PurchasedDate { get; set; }
    }
}