using System.ComponentModel.DataAnnotations;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;

namespace TesteVagaDevPleno.Modules.ProductModule.Dtos
{
    public class ICreateProductDTO
    {
       
 
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price_product is required")]
        public float Price_product { get; set; }

        [Required(ErrorMessage = "categoryid is required")]
        [MaxLength(150)]
        public string categoryid { get; set; }

    }
}
