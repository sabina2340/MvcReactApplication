using ApplicationMVC1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITrelationService
    {
        IEnumerable<Trelation> GetAll();
        Trelation GetById(int id);
        Trelation Create(Trelation model);
        Trelation Update(int id, Trelation updatedModel);
        void Delete(int id);
    }
}
