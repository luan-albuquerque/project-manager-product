using System.Data;

namespace TesteVagaDevPleno.Modules.ProductModule.Dtos
{
    public class IQueryProductRequest
    {
        public int? Take { get; set; }
        public int? Skip { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
   
    }
}
