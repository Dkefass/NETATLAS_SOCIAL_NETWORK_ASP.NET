using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class Ressource
    {
        [Key]
        public int id_ressource { get; set; }

        [Required, MinLength(3), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        public string nom_ressource { get; set; }

       

        public ICollection<Publication> Publication { get; set; }

        public ICollection<Message> Message { get; set; }
        public ICollection<ReponseMessage> ReponseMessage { get; set; }
        public ICollection<PhotoVideo> PhotoVideo{ get; set; }
        public ICollection<Lien> Lien { get; set; }

    }
}
