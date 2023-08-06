using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UberEats.Models
{
    public class Partner
    {
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
      public int CategoryID { get; set; } 

      [ValidateNever]
      public Category Category { get; set; } = null!;

      public List<Item> Menu { get; set; } = new List<Item>();
      
      public string LogoImage { get; set; } = string.Empty;
        public string Slug
        {
            get
            {
                if (BusinessName == null)
                    return "";
                else
                    return BusinessName.Replace(' ', '-');
            }
        }
    }
}