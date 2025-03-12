using System;
using System.ComponentModel.DataAnnotations;
namespace InvSysMan.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public required string ProductName { get; set; }

        public decimal Price { get; set; }

        public int ProductQuantity { get; set; }

        [Required]
        [MaxLength(100)]
        public required string SupplierName { get; set; }
    }
}
