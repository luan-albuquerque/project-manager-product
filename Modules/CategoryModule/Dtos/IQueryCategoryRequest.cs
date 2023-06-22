namespace TesteVagaDevPleno.Modules.CategoryModule.Dtos
{
    public class IQueryCategoryRequest
    {
        public int? Take { get; set; }
        public int? Skip { get; set; }
        public string? Description { get; set; }
    }
}
