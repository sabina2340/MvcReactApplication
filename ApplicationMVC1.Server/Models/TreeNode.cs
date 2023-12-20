using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationMVC1.Server.Models
{
    public class TreeNode
    {
        public string Text { get; set; }
        public string Name { get; set; }

        public int Id { get; set; }
        public List<TreeNode> Nodes { get; set; }

        public TreeNode()
        {
            Nodes = new List<TreeNode>();
        }
    }
}
