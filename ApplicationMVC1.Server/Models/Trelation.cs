using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ApplicationMVC1.Server.Models
{
    public class Trelation
    {
        public int Id { get; set; }

        public int ParentGroupId { get; set; }
        public Tgroup? ParentGroup { get; set; }

        public int ChildGroupId { get; set; }
        public Tgroup? ChildGroup { get; set; }
    }
}
