using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UberEats.Models
{
    public class Partner
    {
      // EF will instruct the database to automatically generate this value
      public int PartnerID { get; set; }

      [Required(ErrorMessage = "Please enter a BusinessName.")]
      public string BusinessName { get; set; } = string.Empty;

      [Required(ErrorMessage = "Please enter a BusinessAddress.")]
      public string BusinessAddress { get; set; } = string.Empty;

      [Required(ErrorMessage = "Please enter a BusinessEmail.")]
      public string BusinessEmail { get; set; } = string.Empty;

      [Required(ErrorMessage = "Please enter a BusinessPhone.")]
      public string BusinessPhone { get; set; }

      [Required(ErrorMessage = "Please select a category.")]
      public int DriverID { get; set; } 

      [ValidateNever]
      public Driver Driver { get; set; } = null!;
      
      public string LogoImage { get; set; } = string.Empty;
    }
}