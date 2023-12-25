using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMVC1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TpropertyController : ControllerBase
    {
        private readonly ITpropertyService _tpropertyService;

        public TpropertyController(ITpropertyService tpropertyService)
        {
            _tpropertyService = tpropertyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _tpropertyService.GetAll();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _tpropertyService.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tproperty model)
        {
            var createdModel = _tpropertyService.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = createdModel.Id }, createdModel);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, Tproperty updatedModel)
        {
            var existingModel = _tpropertyService.Update(id, updatedModel);

            if (existingModel == null)
            {
                return NotFound();
            }

            return Ok(existingModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tpropertyService.Delete(id);
            return NoContent();
        }
    }

}

