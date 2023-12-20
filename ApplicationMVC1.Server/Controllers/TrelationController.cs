using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMVC1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrelationController : ControllerBase
    {
        private readonly ITrelationService _trelationService;

        public TrelationController(ITrelationService trelationService)
        {
            _trelationService = trelationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _trelationService.GetAll();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _trelationService.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(Trelation model)
        {
            var createdModel = _trelationService.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = createdModel.Id }, createdModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Trelation updatedModel)
        {
            var existingModel = _trelationService.Update(id, updatedModel);

            if (existingModel == null)
            {
                return NotFound();
            }

            return Ok(existingModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _trelationService.Delete(id);
            return NoContent();
        }
    }
}

