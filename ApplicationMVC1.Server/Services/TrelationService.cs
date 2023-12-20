using ApplicationMVC1.Server.Data;
using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMVC1.Server.Services
{
    public class TrelationService : ITrelationService
    {
        private readonly MyDataContext _dataContext;

        public TrelationService(MyDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Trelation> GetAll()
        {
            return _dataContext.Trelations.ToList();
        }

        public Trelation GetById(int id)
        {
            return _dataContext.Trelations.Find(id);
        }

        public Trelation Create(Trelation model)
        {
            _dataContext.Trelations.Add(model);
            _dataContext.SaveChanges();
            return model;
        }

        public Trelation Update(int id, Trelation updatedModel)
        {
            var existingModel = _dataContext.Trelations.Find(id);

            if (existingModel != null)
            {
                existingModel.ParentGroupId = updatedModel.ParentGroupId;
                existingModel.ChildGroupId = updatedModel.ChildGroupId;

                _dataContext.SaveChanges();
            }

            return existingModel;
        }

        public void Delete(int id)
        {
            var modelToDelete = _dataContext.Trelations.Find(id);

            if (modelToDelete != null)
            {
                _dataContext.Trelations.Remove(modelToDelete);
                _dataContext.SaveChanges();
            }
        }
    }

}

