using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;
using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Entity;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;
using TesteVagaDevPleno.Modules.ProductModule.Services;

namespace TesteVagaDevPleno.Controllers
{

    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
 

        // Service
        private readonly CreateProductService _createService;
        private readonly FindAllProductService _findAllProductService;
        private readonly FindOneProductService _findOneProductService;
        private readonly DeleteProductService _deleteProductService;
        private readonly UpdateProductService _updateProductService;


        public ProductController(
            ProductRepository _productRepository,
            CategoryRepository _categoryRepository
            )
        {
            _createService = new CreateProductService(_productRepository);
            _findAllProductService = new FindAllProductService(_productRepository);
            _findOneProductService = new FindOneProductService(_productRepository);
            _deleteProductService = new DeleteProductService(_productRepository);
            _updateProductService = new UpdateProductService(_productRepository, _categoryRepository);
        }

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(ICreateProductDTO createProductDTO)
        {
            try {
                await _createService.Execute(createProductDTO);

                return Created("created product success", createProductDTO);

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FindAll([FromQuery] IQueryProductRequest query)
        {
            try
            {

             return Ok(await _findAllProductService.Execute(query));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
             }    

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> FindOne(string id)
        {
            try
            {

                return Ok(await _findOneProductService.Execute(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(string id)
        {
            try
            {
                await _deleteProductService.Execute(id);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(string id, IUpdateProductDTO updateProductDTO)
        {
            try
            {
                await _updateProductService.Execute(id, updateProductDTO);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
