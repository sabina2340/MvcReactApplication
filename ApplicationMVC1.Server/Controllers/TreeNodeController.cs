using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMVC1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeNodeController : ControllerBase
    {
        private ITreeNodeService _treeNodeService;

        public TreeNodeController(ITreeNodeService treeNodeService)
        {
            _treeNodeService = treeNodeService;
        }

        [HttpPost]
        public TreeNode Create(TreeNode model)
        {
            return _treeNodeService.Create(model);
        }

        [HttpPatch]
        public TreeNode Update(TreeNode model)
        {
            return _treeNodeService.Update(model);
        }

        [HttpGet("{id}")]
        public TreeNode Get(int id)
        {
            return _treeNodeService.Get(id);
        }

        [HttpGet]
        public IEnumerable<TreeNode> GetAll()
        {
            return _treeNodeService.GetAll();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _treeNodeService.Delete(id);

            return Ok();
        }
    }
}
