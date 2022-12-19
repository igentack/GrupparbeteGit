using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(64, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        [Display(Name = "Beställningsdatum"), DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }

        [Required, StringLength(64, MinimumLength = 2)]
        public string Category { get; set; } = string.Empty;

        public string Shelf { get; set; } = string.Empty;

        public int Count { get; set; }

        public string Description { get; set; }

    }

}
