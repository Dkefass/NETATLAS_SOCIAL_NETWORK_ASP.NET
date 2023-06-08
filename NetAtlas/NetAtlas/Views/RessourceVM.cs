using System.ComponentModel.DataAnnotations;

namespace NetAtlas.Views
{
    public class RessourceVM
    {

        [Required, MinLength(3)]
        public string nom_ressource { get; set; }

    }
}
