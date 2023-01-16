using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }


        public DateTime TimeDeparture { get; set; }

        public DateTime TimeArrival { get; set; }

        public double TotalCost { get; set; }

        [Required]
        public Member Member { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }


    }
}
