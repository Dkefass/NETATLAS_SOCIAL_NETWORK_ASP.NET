using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace NetAtlas.Models
{
    public class Membre
    {

        
       
        [Key, EmailAddress, Index(IsUnique = true), Column(TypeName = "VARCHAR"), Required]
        public string email { get; set; }


        [Required, MinLength(3), Column(TypeName = "VARCHAR")]
        public string nom { get; set; }

        [Required, MinLength(3), Column(TypeName = "VARCHAR")]
        public string prenom { get; set; }

        [Required, MinLength(3), Column(TypeName = "VARCHAR")]
        public string sexe { get; set; }


        [MinLength(5), Required, DataType(DataType.Password)]
        public String mot_de_passe { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? date_de_cretaation { get; set; }

        [ScaffoldColumn(false)]
        public string image_url { get; set; }

        public ICollection<Publication> Publication { get; set; }
        public ICollection<ListeAmis> ListeAmis { get; set; }
        public ICollection<TypeAmis> TypeAmis { get; set; }

        [ MinLength(3), Column(TypeName = "VARCHAR")]
        public string statut { get; set; }
       


    }
}
