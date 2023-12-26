using ApplicationMVC1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITpropertyService
    {
        IEnumerable<Tproperty> GetAll();
        Tproperty GetById(int id);
        Tproperty Create(Tproperty model);
        Tproperty Update(int id, Tproperty updatedModel);
        void Delete(int id);
        Tproperty UpdatePart(int id, Tproperty updatedModel);
    }

}
