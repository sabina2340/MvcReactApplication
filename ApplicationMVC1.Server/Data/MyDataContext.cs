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
        }

    }
}
