namespace ApplicationMVC1.Server.Models
{
    public class Trelation
    {
        public int Id { get; set; }
        public int ParentGroupId { get; set; }
        public int ChildGroupId { get; set; }
        public Tgroup ParentGroup { get; set; }
        public Tgroup ChildGroup { get; set; }
    }
}
