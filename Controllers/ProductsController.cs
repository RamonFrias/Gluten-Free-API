using GlutenFreeApi.Context;
using GlutenFreeApi.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlutenFreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GlutenFreeApiContext? _context;
        public ProductsController(GlutenFreeApiContext? context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Informe um id válido!");

                var product = await _context.Products.SingleOrDefaultAsync(product => product.Id == id);
                if (product == null)
                {
                    return NotFound("Produto não encontrado!");
                }
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return NotFound("Informe o produto corretamente!");
                }
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutProcuct(int id, Product product)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Informe um id válido!");

                if (id != product.Id)
                    return BadRequest("Id da URL diferente do Id do produto!");

                var existingProduct = await _context.Products.FindAsync(id);
                if (existingProduct == null)
                    return NotFound("Produto não encontrado!");
                
                _context.Entry(product).CurrentValues.SetValues(existingProduct);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Informe um id válido!");

                var existingProduct = await _context.Products.FindAsync(id);
                if (existingProduct == null)
                    return NotFound("produto não encontrado");

                _context.Products.Remove(existingProduct);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão");
            }
        }
    }
}
