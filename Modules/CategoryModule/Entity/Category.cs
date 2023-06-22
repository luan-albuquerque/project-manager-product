using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteVagaDevPleno.Modules.CategoryModule.Entity
{


    [Table("Category")]
    public class Category
    {
     

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; private set; } = null!;
 
        [Required]
        [MaxLength(150)]
        public string description { get; private set; }

        public Category(string description)
        {
            this.description = description;
        }



    }
}
