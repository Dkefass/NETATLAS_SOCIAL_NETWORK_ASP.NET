using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class TypeAmis
    {
        [Key]
        public int id_typeamis { get; set; }

        [Required, MinLength(3), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        public string nom_type { get; set; }

        



    }
}
