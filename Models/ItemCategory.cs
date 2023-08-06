using System.ComponentModel.DataAnnotations;

namespace UberEats.Models
{
    public class ItemCategory
    {
        public int ItemCategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a Item category name.")]
        public string Name { get; set; } = string.Empty;
    }
}
