using ApplicationMVC1.Server.Data;
using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ApplicationMVC1.Server.Services
{
    public class TgroupService : ITgroupService
    {
        private readonly MyDataContext _dataContext;

        public TgroupService(MyDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Tgroup> GetAll()
        {
            return _dataContext.Tgroups.ToList();
        }

        public Tgroup GetById(int id)
        {
            return _dataContext.Tgroups.Find(id);
        }

        public Tgroup Create(Tgroup model)
        {
            _dataContext.Tgroups.Add(model);
            _dataContext.SaveChanges();
            return model;
        }

        public Tgroup Update(int id, Tgroup updatedModel)
        {
            var existingModel = _dataContext.Tgroups.Find(id);

            if (existingModel != null)
            {
                existingModel.Name = updatedModel.Name;
                _dataContext.SaveChanges();
            }

            return existingModel;
        }
        public void Delete(int id)
        {
            var modelToDelete = _dataContext.Tgroups.Find(id);

            if (modelToDelete != null)
            {
                _dataContext.Tgroups.Remove(modelToDelete);
                _dataContext.SaveChanges();
            }
        }
    }
}