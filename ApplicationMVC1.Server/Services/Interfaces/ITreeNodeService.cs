using ApplicationMVC1.Server.Models;

namespace ApplicationMVC1.Server.Services.Interfaces
{
    public interface ITreeNodeService
    {
        TreeNode Create(TreeNode model);
        TreeNode Update(TreeNode model);
        TreeNode Get(int id);
        IEnumerable<TreeNode> GetAll();
        void Delete(int id);
    }
}
