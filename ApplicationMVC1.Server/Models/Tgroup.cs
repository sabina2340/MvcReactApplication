namespace ApplicationMVC1.Server.Models
{
    public class Tgroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Tproperty> Properties { get; set; } = new List<Tproperty>();
    }
}
