using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class Publication
    {
        [Key]
        public int id_publication { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? date_de_publication { get; set; }


        
       


        
       

    }
}
