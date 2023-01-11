using Lipy.HeaderApi.Interfaces;
using Lipy.HeaderApi.Model;
using Lipy.HeaderApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Lipy.HeaderApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IHeaderRepository _headerRepository;


        public HeaderController(IHeaderRepository productRepository)
        {
            _headerRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Header>>> Get()
        {
            var products = await _headerRepository.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Header>> Get(Guid id)
        {
            var product = await _headerRepository.GetById(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Header>> Post([FromBody] HeaderViewModel value)
        {
            if (value.IsValid)
            {
                var product = new Header(value.Title, value.Link);
                await _headerRepository.Add(product);
                
                var header = await _headerRepository.GetById(product.Id);

                return Ok(header);
            }
            return BadRequest("Json invalid.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Header>> Put(Guid id, [FromBody] HeaderViewModel value)
        {
            if (value.IsValid) 
            {
                var entity = await _headerRepository.GetById(id);
                
                entity.Title = value.Title;
                entity.Link = value.Link;
                entity.LastChangedOn = DateTime.Now;
                //var product = new Header(id, value.Title, value.Link);

                await _headerRepository.UpdateAsync(entity);


                return Ok(await _headerRepository.GetById(id));
            }

            return BadRequest("Error occurred");
         
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _headerRepository.Remove(id);

            return Ok();
        }
    }
}
