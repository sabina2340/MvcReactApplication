using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using MvcApplication.data;
//using MvcApplication.Models;
//using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ApplicationMVC1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TgroupController : ControllerBase
    {
        private ITgroupService _tgroupService;

        public TgroupController(ITgroupService tgroupService)
        {
            _tgroupService = tgroupService;
        }

        [HttpPost]
        public Tgroup Create(Tgroup model)
        {
            return _tgroupService.Create(model);
        }

        [HttpPatch]
        public Tgroup Update(Tgroup model)
        {
            return _tgroupService.Update(model);
        }

        [HttpGet("{id}")]
        public Tgroup Get(int id)
        {
            return _tgroupService.Get(id);
        }

        [HttpGet]
        public IEnumerable<Tgroup> GetAll()
        {
            return _tgroupService.Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tgroupService.Delete(id);

            return Ok();
        }
    }

}
