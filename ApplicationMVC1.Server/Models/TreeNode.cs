using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationMVC1.Server.Models
{
    public class TreeNode
    {
        public string Text { get; set; } // поле Name из Tgroup/Tproperty
        public string Name { get; set; } // id из Tgroup/Tproperty + "|" + "Group/Property" 
        // пример:
        //Text = "Name1"
        // Name = "1|Group"
    }
}
