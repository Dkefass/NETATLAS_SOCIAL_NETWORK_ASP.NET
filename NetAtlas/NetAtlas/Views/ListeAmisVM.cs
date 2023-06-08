using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Views
{
    public class ListeAmisVM
    {

        [Key]
        public int ListeAmisId { get; set; }
        [ EmailAddress, Index(IsUnique = true), Required]
        public string Membre_email { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? date_amitie { get; set; }

        [EmailAddress, Index(IsUnique = true),Required]
        public string email_amis { get; set; }
       
    }
}
