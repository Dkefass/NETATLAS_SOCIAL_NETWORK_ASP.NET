using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace NetAtlas.Views
{
    public class PhotoVideoVM
    {
        public string nom_ressource = "Photo et Video";

        [Required, MinLength(3)]
        public String nom_photovideo { get; set; }

        [ScaffoldColumn(false)]
        public string photovideo_url { get; set; }

        [Required, MinLength(3)]
        public string Taille { get; set; }

        
             
    }
}
