using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class PhotoVideo
      
    {
        [Key]
        public int photovideo_id { get; set; }
        [Required, MinLength(3), Column(TypeName = "VARCHAR")]
        public String nom_photovideo { get; set; }

        [ScaffoldColumn(false)]
        public string photovideo_url { get; set; }

        [Required, MinLength(3), Column(TypeName = "VARCHAR")]
        public string Taille { get; set; }
        
    }
}
