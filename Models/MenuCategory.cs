using System.ComponentModel.DataAnnotations;

namespace UberEats.Models
{
    public class MenuCategory
    {
        public int MenuCategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a Menu category name.")]
        public string Name { get; set; } = string.Empty;
    }
}
