using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class ReponseMessage 
    {

        [Key]
        public int  reponsemessage_id { get; set; }

        [Required, MinLength(3), Column(TypeName = "VARCHAR")]
        public string text { get; set; }
        
        
        public ICollection<Message> Message { get; set; }

       
    }
}
