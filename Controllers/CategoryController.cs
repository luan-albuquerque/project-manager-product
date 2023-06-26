using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TesteVagaDevPleno.Modules.AuthModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;
using TesteVagaDevPleno.Modules.CategoryModule.Services;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;
using TesteVagaDevPleno.Modules.UserModule.Entity;

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
        [SwaggerOperation(Summary = "Criação de Categoria", Description = "EndPoint para criar categorias")]
        [ProducesResponseType(typeof(ICreateCategoryDTO), StatusCodes.Status200OK)]
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
        [SwaggerOperation(Summary = "Buscar Categoria", Description = "EndPoint para buscar uma categoria especifica")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]

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
        [SwaggerOperation(Summary = "Listar todas as categorias", Description = "EndPoint para listar todas as categorias cadastradas")]

        [ProducesResponseType(typeof(User[]), StatusCodes.Status200OK)]
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
        [SwaggerOperation(Summary = "Atualizar Categoria", Description = "EndPoint para atualizar uma categoria pelo identificador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
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
        [SwaggerOperation(Summary = "Deletar Categoria", Description = "EndPoint para deletar uma categoria pelo identificador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
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
