using ApplicationMVC1.Server.Data;
using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;

namespace ApplicationMVC1.Server.Services
{
    public class TpropertyService : ITpropertyService
    {
        private MyDataContext _dataContext;

        public TpropertyService(MyDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Tproperty Create(Tproperty model)
        {
            var lastTproperty = _dataContext.Tproperties.LastOrDefault();
            int newId = lastTproperty is null ? 1 : lastTproperty.Id + 1;

            model.Id = newId;
            _dataContext.Tproperties.Add(model);

            return model;
        }

        public Tproperty Update(Tproperty model)
        {
            var modelToUpdate = _dataContext.Tproperties.FirstOrDefault(x => x.Id == model.Id);

            if (modelToUpdate != null)
            {
                modelToUpdate.Name = model.Name;
                modelToUpdate.Value = model.Value;
                modelToUpdate.Group_id = model.Group_id;
                modelToUpdate.Group = model.Group; 
            }

            return modelToUpdate;
        }

        public void Delete(int id)
        {
            var modelToDelete = _dataContext.Tproperties.FirstOrDefault(x => x.Id == id);

            if (modelToDelete != null)
            {
                _dataContext.Tproperties.Remove(modelToDelete);
            }
        }

        public Tproperty Get(int id)
        {
            return _dataContext.Tproperties.FirstOrDefault(x => x.Id == id);
        }

        public List<Tproperty> Get()
        {
            return _dataContext.Tproperties;
        }
    }

}

