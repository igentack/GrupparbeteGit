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

        [StringLength(64, MinimumLength = 3)]
        public string Shelf { get; set; } = string.Empty;

        public int Count { get; set; }
        [StringLength(256, MinimumLength = 3)]
        public string? Description { get; set; }

    }

}
