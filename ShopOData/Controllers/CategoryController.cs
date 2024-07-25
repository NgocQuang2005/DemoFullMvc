using Microsoft.AspNetCore.Mvc;
using ShopBussinessObject;
using ShopRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOData.Controllers
{
    [Route("odata")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        // GET: api/<CategoryController>
        public CategoryController()
        {
            categoryRepository = new CategoryRepository(); 
        }
        [HttpGet("[controller]")]
        public async Task<IEnumerable<Category>> Get()
        {
            var category = await categoryRepository.GetCategories();
            return category;
        }

        // GET api/<CategoryController>/5
        [HttpGet("[controller]({id})")]
        public async Task<Category> Get(int id)
        {
            var category = await categoryRepository.GetById(id);
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost("[controller]")]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await categoryRepository.Create(category);
            return Ok(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("[controller]({id})")]
        public async Task<ActionResult> Put(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await categoryRepository.GetById(id);
            if (exist == null)
            {
                return NotFound();
            }
            category.CategoryId = id;
            await categoryRepository.Update(category);
            return Ok("Update success!\n");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("[controller]({id})")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await categoryRepository.GetById(id);
            if (exist == null)
            {
                return NotFound();
            }
            await categoryRepository.Delete(id);
            return Ok("Delete success\n");
        }
    }
}
