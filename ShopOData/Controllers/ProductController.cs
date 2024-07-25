using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShopBussinessObject;
using ShopDTO;
using ShopRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOData.Controllers
{
    [Route("odata")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductController(IMapper mapper)
        {
            productRepository = new ProductRepository();
            this.mapper = mapper;
        }
        // GET: api/<ProductController>
        [EnableQuery]
        [HttpGet("[controller]")]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var product = await productRepository.GetProducts();
            var productDTO = mapper.Map<IEnumerable<ProductDTO>>(product);
            return productDTO;
        }
        // GET api/<CategoryController>/5
        [HttpGet("[controller]({id})")]
        public async Task<Product> Get(int id)
        {
            var product = await productRepository.GetById(id);
            return product;
        }

        // POST api/<CategoryController>
        [HttpPost("[controller]")]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await productRepository.Create(product);
            return Ok(product);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("[controller]({id})")]
        public async Task<ActionResult> Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await productRepository.GetById(id);
            if (exist == null)
            {
                return NotFound();
            }
            product.CategoryId = id;
            await productRepository.Update(product);
            return Ok("Update success!\n");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("[controller]({id})")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await productRepository.GetById(id);
            if (exist == null)
            {
                return NotFound();
            }
            await productRepository.Delete(id);
            return Ok("Delete success\n");
        }
    }
}
