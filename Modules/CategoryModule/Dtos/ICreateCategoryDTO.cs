using System.ComponentModel.DataAnnotations;

namespace TesteVagaDevPleno.Modules.CategoryModule.Dtos
{
    public class ICreateCategoryDTO
    {
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(150)]
        public string description { get; set; }
    }
}
