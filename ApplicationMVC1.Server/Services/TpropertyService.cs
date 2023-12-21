using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Repository;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMVC1.Server.Services
{
    public class TpropertyService : ITpropertyService
    {
        private readonly MyDataContext _dataContext;

        public TpropertyService(MyDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Tproperty> GetAll()
        {
            return _dataContext.Tproperties.ToList();
        }

        public Tproperty GetById(int id)
        {
            return _dataContext.Tproperties.Find(id);
        }

        public Tproperty Create(Tproperty model)
        {
            _dataContext.Tproperties.Add(model);
            _dataContext.SaveChanges();
            return model;
        }

        public Tproperty Update(int id, Tproperty updatedModel)
        {
            var existingModel = _dataContext.Tproperties.Find(id);

            if (existingModel != null)
            {
                existingModel.Name = updatedModel.Name;
                existingModel.Value = updatedModel.Value;
                existingModel.GroupId = updatedModel.GroupId;

                _dataContext.SaveChanges();
            }

            return existingModel;
        }

        public void Delete(int id)
        {
            var modelToDelete = _dataContext.Tproperties.Find(id);

            if (modelToDelete != null)
            {
                _dataContext.Tproperties.Remove(modelToDelete);
                _dataContext.SaveChanges();
            }
        }
    }
}

