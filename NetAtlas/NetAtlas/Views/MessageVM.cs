using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Views
{
    public class MessageVM
    {
        [Required, MinLength(3)]
        public string text { get; set; }


      public  string nom_ressource = "Message";
    }
}
