using ApplicationMVC1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITgroupService
    {
            Tgroup Create(Tgroup model);

            Tgroup Update(Tgroup model);

            Tgroup Get(int id);

            DbSet<Tgroup> Get();

            void Delete(int id);
    }
}
