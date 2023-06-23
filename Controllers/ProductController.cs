using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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


        public ProductController(ProductRepository _productRepository)
        {
            _createService = new CreateProductService(_productRepository);
            _findAllProductService = new FindAllProductService(_productRepository);
            _findOneProductService = new FindOneProductService(_productRepository);
            _deleteProductService = new DeleteProductService(_productRepository);
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
    }
}
