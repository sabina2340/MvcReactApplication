using ApplicationMVC1.Server.Models;

namespace ApplicationMVC1.Server.Data
{
    public class MyDataContext
    {
        public List<Tgroup> Tgroups { get; set; }
        public List<Trelation> Trelations { get; set; }
        public List<Tproperty> Tproperties { get; set; }

        public MyDataContext()
        {
            Tgroups = new List<Tgroup>();

            Trelations= new List<Trelation>();

            Tproperties = new List<Tproperty>();    
        }
    }
}
