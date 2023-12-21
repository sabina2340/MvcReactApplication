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

        [HttpGet]
        public IActionResult GetTree()
        {
            var tree = _treeService.GetTree();
            return Ok(tree);
        }
    }
}
