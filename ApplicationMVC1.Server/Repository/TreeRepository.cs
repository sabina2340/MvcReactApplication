using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Repository.Interfaces;

namespace ApplicationMVC1.Server.Repository
{
    public class TreeRepository : ITreeRepository
    {
        private readonly MyDataContext _context;

        public TreeRepository(MyDataContext context)
        {
            _context = context;
        }

        public Tgroup GetRoot()
        {
            // Вернуть корневую группу (где Id = 1) из базы данных
            return _context.Tgroups.FirstOrDefault(g => g.Id == 1);
        }

        
        public List<Tgroup> GetChildGroups(int parentId)
        {   
            // Вернуть дочерние группы для указанного parentId из базы данных
            var childGroupIds = _context.Trelations
                .Where(r => r.ParentGroupId == parentId)
                .Select(r => r.ChildGroupId)
                .ToList();

            var childGroups = _context.Tgroups
                .Where(g => childGroupIds.Contains(g.Id))
                .ToList();

            return childGroups;
        }

        public List<Tproperty> GetChildProperties(int groupId)
        {
            // Вернуть свойства для указанной группы из базы данных
            return _context.Tproperties.Where(p => p.GroupId == groupId).ToList();
        }
    }
}
