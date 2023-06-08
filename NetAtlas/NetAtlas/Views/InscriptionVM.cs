using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Views
{
    public class InscriptionVM
    {
        [Required, MinLength(3)]
        public string nom { get; set; }

        [Required, MinLength(3)]
        public string prenom { get; set; }

        [MinLength(5), Required, DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public String mot_de_passe { get; set; }

        [Compare("mot_de_passe"), DataType(DataType.Password)]
        [Display(Name ="Confirmer le mot de passe")]
        public String mot_de_passe_Conf { get; set; }
        [EmailAddress, Required]
        public string email { get; set; }

        [Required, MinLength(3)]
        public string statut = "Guest";

        [Required, MinLength(3)]
        public string sexe { get; set; }

        [ScaffoldColumn(false)]
        public string image_url { get; set; }




    }
}
