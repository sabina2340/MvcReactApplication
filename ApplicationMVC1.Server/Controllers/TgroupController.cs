using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMVC1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TgroupController : ControllerBase
    {
        private readonly ITgroupService _tgroupService;

        public TgroupController(ITgroupService tgroupService)
        {
            _tgroupService = tgroupService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _tgroupService.GetAll();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _tgroupService.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(Tgroup model)
        {
            var createdModel = _tgroupService.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = createdModel.Id }, createdModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tgroup updatedModel)
        {
            var existingModel = _tgroupService.Update(id, updatedModel);

            if (existingModel == null)
            {
                return NotFound();
            }

            return Ok(existingModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tgroupService.Delete(id);
            return NoContent();
        }
    }
}
