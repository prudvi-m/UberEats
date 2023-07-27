using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UberEats.Models
{
    public class MenuItem
    {
      
      public int MenuItemID { get; set; }

      public string Name { get; set; }

      [Required(ErrorMessage = "Please enter a Price.")]
      public double Price { get; set; } = 0.0;

      [Required(ErrorMessage = "Please enter a Description.")]
      public string Description { get; set; } = string.Empty;

      [Required(ErrorMessage = "Please enter a PartnerId.")]
      public int PartnerID { get; set; }

      [Required(ErrorMessage = "Please select a menu category.")]
      public int MenuCategoryID { get; set; } 

      [ValidateNever]
      public MenuCategory MenuCategory { get; set; } = null!;
    
    }
}