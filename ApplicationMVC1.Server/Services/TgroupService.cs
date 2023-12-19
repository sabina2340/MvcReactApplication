using ApplicationMVC1.Server.Data;
using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ApplicationMVC1.Server.Services
{
    public class TgroupService : ITgroupService
    {
        private MyDataContext _dataContext;

        public TgroupService(MyDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Tgroup Create(Tgroup model)
        {
            var lastTgroup = _dataContext.Tgroups.LastOrDefault();
            int newId = lastTgroup is null ? 1 : lastTgroup.Id + 1;

            model.Id = newId;
            _dataContext.Tgroups.Add(model);

            return model;
        }

        public Tgroup Update(Tgroup model)
        {
            var modelToUpdate = _dataContext.Tgroups.FirstOrDefault(x => x.Id == model.Id);

            if (modelToUpdate != null)
            {
                modelToUpdate.Name = model.Name;
            }

            return modelToUpdate;
        }

        public void Delete(int id)
        {
            var modelToDelete = _dataContext.Tgroups.FirstOrDefault(x => x.Id == id);

            if (modelToDelete != null)
            {
                _dataContext.Tgroups.Remove(modelToDelete);
            }
        }

        public Tgroup Get(int id)
        {
            return _dataContext.Tgroups.FirstOrDefault(x => x.Id == id);
        }

        public DbSet<Tgroup> Get()
        {
            return _dataContext.Tgroups;
        }
    }

}