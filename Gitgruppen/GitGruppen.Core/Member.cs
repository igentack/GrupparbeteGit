using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
    public class Member
    {
        [Key]
        public string PersNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
