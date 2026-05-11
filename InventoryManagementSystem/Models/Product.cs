using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public string? CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public string? ImagePath { get; set; }

        [Column(TypeName = ("decimal(18,2)"))]
        public decimal? CostPrice { get; set; }

        [Column(TypeName = ("decimal(18,2)"))]
        public decimal? SellingPrice { get; set; }

        public int? StockQuantity { get; set; }

        public int? LowStackTreshold { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        //public Category Category { get; set; }

    }
}
