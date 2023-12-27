using ApplicationMVC1.Server.Models;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITreeService
    {
        public List<TreeNode> GetChildGroups(int id);
        public List<TreeNode> GetChildProperties(int id);
        TreeNode GetRoot();
 
    }

}
