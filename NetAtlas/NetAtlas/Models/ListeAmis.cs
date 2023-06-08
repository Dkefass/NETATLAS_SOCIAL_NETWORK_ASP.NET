using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class ListeAmis
    {


        [Key]
        public int ListeAmisId { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? date_amitie { get; set; }
        
        [ EmailAddress, Index(IsUnique = true), Column(TypeName = "VARCHAR"), Required]
        public  string email_amis { get; set; }
        [EmailAddress, Index(IsUnique = true), Column(TypeName = "VARCHAR"), Required]
        public string Membres_mail { get; set; }




    }
}
