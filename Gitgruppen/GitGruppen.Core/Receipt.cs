using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
#nullable disable
    public class Receipt
    {
        // Composite Key?
        public int Id { get; set; }  

        public DateTime TimeDeparture { get; set; }

        public DateTime TimeArrival { get; set; }

        public double TotalCost { get; set; }


        /*[Required]*/
        public Member Member { get; set; }    

        /*[Required]*/
        public Vehicle Vehicle { get; set; }

        
    }
}
