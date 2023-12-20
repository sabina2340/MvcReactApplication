using System.ComponentModel.DataAnnotations;

namespace ApplicationMVC1.Server.Models
{
    public class Tgroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
