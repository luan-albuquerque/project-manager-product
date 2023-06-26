using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;
using TesteVagaDevPleno.Modules.CategoryModule.Services;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;

namespace TesteVagaDevPleno.Controllers
{

    [Route("category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {

        private readonly CreateCategoryService _createCategoryService;  
        private readonly FindAllCategoryService _findAllCategoryService;
        private readonly FindOneCategoryService _findOneCategoryService;
        private readonly UpdateCategoryService _updateCategoryService;
        private readonly DeleteCategoryService _deleteCategoryService;

        public CategoryController(
              ProductRepository _productRepository,
              CategoryRepository _categoryRepository
            )
        {
            _updateCategoryService = new UpdateCategoryService(_categoryRepository);
            _createCategoryService = new CreateCategoryService(_categoryRepository);
            _findAllCategoryService = new FindAllCategoryService(_categoryRepository);
            _findOneCategoryService = new FindOneCategoryService(_categoryRepository);
            _deleteCategoryService = new DeleteCategoryService(_categoryRepository);


        }


        [HttpPost("")]
        public async Task<IActionResult> Create(ICreateCategoryDTO createCategoryDTO) 
        {

            try {

                await _createCategoryService.execute(createCategoryDTO);


                return Created("created category success", createCategoryDTO);
               
            }catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{id}")]
      
        public async Task<IActionResult> FindOne(string id)
        {

            try
            {



                return Ok(await _findOneCategoryService.Execute(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] IQueryCategoryRequest query)
        {

            try
            {

                
                return Ok(await _findAllCategoryService.Execute(query));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(string id, IUpdateCategoryDTO updateCategoryDTO)
        {

            try
            {
                await _updateCategoryService.Execute(id, updateCategoryDTO);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
  
        public async Task<IActionResult> Remove(string id)
        {

            try
            {
                await _deleteCategoryService.Execute(id);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
