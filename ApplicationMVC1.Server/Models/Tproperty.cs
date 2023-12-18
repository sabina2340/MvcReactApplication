namespace ApplicationMVC1.Server.Models
{
    public class Tproperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Group_id { get; set; } 
        public Tgroup Group { get; set; } 
    }
}
