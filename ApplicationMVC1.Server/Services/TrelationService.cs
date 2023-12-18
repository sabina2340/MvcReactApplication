using ApplicationMVC1.Server.Data;
using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Services.Interfaces;

namespace ApplicationMVC1.Server.Services
{
        public class TrelationService : ITrelationService
        {
            private MyDataContext _dataContext;

            public TrelationService(MyDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public Trelation Create(Trelation model)
            {
                var lastTrelation = _dataContext.Trelations.LastOrDefault();
                int newId = lastTrelation is null ? 1 : lastTrelation.Id + 1;

                model.Id = newId;
                _dataContext.Trelations.Add(model);

                return model;
            }

            public Trelation Update(Trelation model)
            {
                var modelToUpdate = _dataContext.Trelations.FirstOrDefault(x => x.Id == model.Id);

                if (modelToUpdate != null)
                {
                    modelToUpdate.ParentGroupId = model.ParentGroupId;
                    modelToUpdate.ChildGroupId = model.ChildGroupId;
                    modelToUpdate.ParentGroup = model.ParentGroup;
                    modelToUpdate.ChildGroup = model.ChildGroup;
                }

                return modelToUpdate;
            }

            public void Delete(int id)
            {
                var modelToDelete = _dataContext.Trelations.FirstOrDefault(x => x.Id == id);

                if (modelToDelete != null)
                {
                    _dataContext.Trelations.Remove(modelToDelete);
                }
            }

            public Trelation Get(int id)
            {
                return _dataContext.Trelations.FirstOrDefault(x => x.Id == id);
            }

            public List<Trelation> Get()
            {
                return _dataContext.Trelations;
           }
     }

}

