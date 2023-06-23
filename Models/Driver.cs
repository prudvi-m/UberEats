using System.ComponentModel.DataAnnotations;

namespace UberEats.Models
{
    public class Driver
    {
        public int DriverID { get; set; }

        [Required(ErrorMessage = "Please enter a category name.")]
        public string Name { get; set; } = string.Empty;
    }
}
