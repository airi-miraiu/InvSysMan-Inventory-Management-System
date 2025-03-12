using System;
using System.ComponentModel.DataAnnotations;

namespace InvSysMan.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        [MaxLength(100)]
        public required string SupplierName { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Phone { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }
    }
}