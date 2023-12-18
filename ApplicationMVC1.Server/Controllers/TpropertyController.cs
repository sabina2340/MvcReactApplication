using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMVC1.Server.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class TpropertyController : ControllerBase
        {
            private ITpropertyService _tpropertyService;

            public TpropertyController(ITpropertyService tpropertyService)
            {
                _tpropertyService = tpropertyService;
            }

            [HttpPost]
            public Tproperty Create(Tproperty model)
            {
                return _tpropertyService.Create(model);
            }

            [HttpPatch]
            public Tproperty Update(Tproperty model)
            {
                return _tpropertyService.Update(model);
            }

            [HttpGet("{id}")]
            public Tproperty Get(int id)
            {
                return _tpropertyService.Get(id);
            }

            [HttpGet]
            public IEnumerable<Tproperty> GetAll()
            {
                return _tpropertyService.Get();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _tpropertyService.Delete(id);

                return Ok();
            }
        }

  }
