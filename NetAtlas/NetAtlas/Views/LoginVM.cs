using System.ComponentModel.DataAnnotations;

namespace NetAtlas.Views
{
    public class LoginVM
    {
        [MinLength(5), Required, DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public String mot_de_passe { get; set; }

        [EmailAddress, Required]
        public string email { get; set; }
       
    }
}
