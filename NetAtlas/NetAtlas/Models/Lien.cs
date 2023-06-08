using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class Lien
    {
        [Key]
        public int Lien_id { get; set; }
  
        [Required, MinLength(1), Column(TypeName = "VARCHAR")]
        public string text { get; set; }

       
    }
}
