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


        public ProductController(ProductRepository _productRepository)
        {
            _createService = new CreateProductService(_productRepository);
            _findAllProductService = new FindAllProductService(_productRepository);
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

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> FindAll(IQueryProductRequest query)
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
    }
}
