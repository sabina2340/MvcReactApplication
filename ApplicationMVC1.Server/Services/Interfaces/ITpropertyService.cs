using ApplicationMVC1.Server.Models;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITpropertyService
    {
            Tproperty Create(Tproperty model);

            Tproperty Update(Tproperty model);

            Tproperty Get(int id);

            List<Tproperty> Get();

            void Delete(int id);
      
        
    }
}
