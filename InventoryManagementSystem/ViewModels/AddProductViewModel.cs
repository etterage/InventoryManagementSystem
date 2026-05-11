using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        [StringLength(150)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public IFormFile? Image { get; set; } = null;

        [Required]
        [StringLength(50)]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [Display(Name = "Cost Price")]
        public decimal? CostPrice { get; set; }

        [Required]
        [Display(Name = "Selling Price")]
        public decimal? SellingPrice { get; set; }

        [Display(Name = "Stock Quantity")]
        public int? StockQuantity { get; set; }

        [Display(Name = "Low Stock Treshold")]
        public int? LowStackTreshold { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        public string? CategoryId { get; set; }
        //public IEnumerable<SelectListItem> Category { get; set; }
    }
}
