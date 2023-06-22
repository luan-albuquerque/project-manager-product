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
        public string id { get; private set; }
        [Required]
        [MaxLength(150)]
        public string name { get; private set; }

        [Required]
        [MaxLength(150)]
        public string description { get; private set; }

        [Required]
        public float price_product { get; private set; }

        [Required]
        public string categoryid { get; private set; }
        
        public Category? category { get; private set; } = null;

        public Product( string name, string description, float price_product, string categoryid)
        {
            this.name = name;
            this.description = description;
            this.price_product = price_product;
            this.categoryid = categoryid;   
        }



    }
}
