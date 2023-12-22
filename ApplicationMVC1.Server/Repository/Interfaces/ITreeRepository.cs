using ApplicationMVC1.Server.Models;

namespace ApplicationMVC1.Server.Repository.Interfaces
{
    public interface ITreeRepository
    {
        Tgroup GetRoot();
        List<Tgroup> GetChildGroups(int parentId);
        List<Tproperty> GetChildProperties(int groupId);
    }
}
