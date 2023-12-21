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

        public Tgroup GetRootGroup()
        {
            // Вернуть корневую группу (где Id = 1) из базы данных
            return _context.Tgroups.FirstOrDefault(g => g.Id == 1);
        }

        public List<Tgroup> GetChildGroups(int parentId)
        {
            // Вернуть дочерние группы для указанного parentId из базы данных
            //return _context.Tgroups.Where(g => g.ParentId == parentId).ToList();
            return new List<Tgroup>();
        }

        public List<Tproperty> GetProperties(int groupId)
        {
            // Вернуть свойства для указанной группы из базы данных
            return _context.Tproperties.Where(p => p.GroupId == groupId).ToList();
        }
    }
}
