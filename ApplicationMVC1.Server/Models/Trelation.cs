using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ApplicationMVC1.Server.Models
{
    public class Trelation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ParentGroup")]
        public int ParentGroupId { get; set; }
        public Tgroup ParentGroup { get; set; }

        [ForeignKey("ChildGroup")]
        public int ChildGroupId { get; set; }
        public Tgroup ChildGroup { get; set; }
    }
}
