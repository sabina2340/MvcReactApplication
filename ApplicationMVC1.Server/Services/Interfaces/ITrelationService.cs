using ApplicationMVC1.Server.Models;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITrelationService
    {
            Trelation Create(Trelation model);

            Trelation Update(Trelation model);

            Trelation Get(int id);

            List<Trelation> Get();

            void Delete(int id);
  

    }
}
