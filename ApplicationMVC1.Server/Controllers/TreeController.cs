using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMVC1.Server.Controllers    
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;     
        }

        [HttpGet("GetRoot")]
        public IActionResult GetRoot()
        {
            var root = _treeService.GetRoot();
            return Ok(root);
        }
        
        [HttpGet("GetChilds/{id}")]
        public IActionResult GetChilds(int id)
        {
            // все дочерние элементы включая и группы и свойства
            var childGroups = _treeService.GetChildGroups(id);
            childGroups.AddRange(_treeService.GetChildProperties(id));
            return Ok(childGroups);
        }

        [HttpGet("GetChildGroups/{id}")]
        public IActionResult GetChildGroups(int id)
        {
            // в данном случае мы получаем дочерние группы только выбранного узла(без дочерних групп дочерних элементов)
            var childGroups = _treeService.GetChildGroups(id);
            return Ok(childGroups);
        }

        [HttpGet("GetChildProperties/{id}")]
        public IActionResult GetChildProperties(int id)
        {
            // дочерние свойства только выбранного узла
            var childProperties = _treeService.GetChildProperties(id);
            return Ok(childProperties);
        }

    }
}
