using System.ComponentModel.DataAnnotations;

namespace TesteVagaDevPleno.Modules.AuthModule.Dtos
{
    public class IAuthDTO
    {
        [Required(ErrorMessage = "email is required")]
        [MaxLength(150)]
        public string email { get; set; }
        [Required(ErrorMessage = "password is required")]
        [MaxLength(150)]
        public string password { get; set; }
    }
}
