using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMVC1.Server.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class TrelationController : ControllerBase
        {
            private ITrelationService _trelationService;

            public TrelationController(ITrelationService trelationService)
            {
                _trelationService = trelationService;
            }

            [HttpPost]
            public Trelation Create(Trelation model)
            {
                return _trelationService.Create(model);
            }

            [HttpPatch]
            public Trelation Update(Trelation model)
            {
                return _trelationService.Update(model);
            }

            [HttpGet("{id}")]
            public Trelation Get(int id)
            {
                return _trelationService.Get(id);
            }

            [HttpGet]
            public IEnumerable<Trelation> GetAll()
            {
                return _trelationService.Get();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _trelationService.Delete(id);

                return Ok();
            }
        }

    
}
