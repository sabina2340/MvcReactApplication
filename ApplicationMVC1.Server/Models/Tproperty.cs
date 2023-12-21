using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ApplicationMVC1.Server.Models
{
    public class Tproperty
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Value { get; set; }

        public int GroupId { get; set; }
        public Tgroup? Group { get; set; }
    }
}
