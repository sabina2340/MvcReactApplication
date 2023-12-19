using ApplicationMVC1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMVC1.Server.Data
{
    
    public class MyDataContext : DbContext
    {
        public DbSet<Tgroup> Tgroups { get; set; }
        public DbSet<Trelation> Trelations { get; set; }
        public DbSet<Tproperty> Tproperties { get; set; }

        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Core_Entity;Username=postgres;Password=sabinamini04;");
        }

        //public MyDataContext()
        //{
        //    Tgroups = new List<Tgroup>();

        //    Trelations= new List<Trelation>();

        //    Tproperties = new List<Tproperty>();    
        //}
    }
}
