using ApplicationMVC1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITgroupService
    {
        IEnumerable<Tgroup> GetAll();
        Tgroup GetById(int id);
        Tgroup Create(Tgroup model);
        Tgroup Update(int id, Tgroup updatedModel);
        void Delete(int id);
    }

}
