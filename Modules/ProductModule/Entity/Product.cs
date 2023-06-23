using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;

namespace TesteVagaDevPleno.Modules.ProductModule.Entity
{

    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get;  set; }
        [Required]
        [MaxLength(150)]
        public string name { get;  set; }

        [Required]
        [MaxLength(150)]
        public string description { get;  set; }

        [Required]
        public float price_product { get;  set; }

        public string categoryid { get;  set; }
        
        public Category? category { get;  set; } = null;




    }
}
