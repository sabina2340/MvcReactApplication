using ApplicationMVC1.Server.Models;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITgroupService
    {
            Tgroup Create(Tgroup model);

            Tgroup Update(Tgroup model);

            Tgroup Get(int id);

            List<Tgroup> Get();

            void Delete(int id);
    }
}
