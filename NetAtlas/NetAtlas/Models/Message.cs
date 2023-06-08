using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class Message 
    {
        [Key]
        public int message_id { get; set; } 
        
        [Required, MinLength(3), Column(TypeName = "VARCHAR")]
        public string text { get; set; }
        public ICollection<ReponseMessage> ReponseMessage { get; set; }
        
    }
}
