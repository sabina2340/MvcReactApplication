using ApplicationMVC1.Server.Models;
using ApplicationMVC1.Server.Repository.Interfaces;
using ApplicationMVC1.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApplicationMVC1.Server.Services
{
    public class TreeService : ITreeService
    {
        private readonly ITreeRepository _treeRepository;
        //// дерево в виде списка узлов
        //List<TreeNode> tree;
        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;

        }

        public TreeNode GetRoot()
        {
            Tgroup rootGroup = _treeRepository.GetRoot();
            var rootNode = new TreeNode
            {
                Text = rootGroup.Name,
                Name = $"{rootGroup.Id}|Group"
            };
            return rootNode;
        }

        public List<TreeNode> GetChildGroups(int id)
        {
            List<TreeNode> childGroups = new List<TreeNode>();
            //дочерние группы из базы данных по parentId
            var childGroupsRepository = _treeRepository.GetChildGroups(id);

            foreach (var childGroup in childGroupsRepository)
            {
                var childNode = new TreeNode
                {
                    Text = childGroup.Name,
                    Name = $"{childGroup.Id}|Group"
                };
                // добавим в список узлов узел группы
                childGroups.Add(childNode);
            }

            return childGroups;
        }
        public List<TreeNode> GetChildProperties(int id)
        {
            List<TreeNode> childProperties = new List<TreeNode>();
            //свойства(Tproperty) для текущей группы
            var childPropertiesRepository = _treeRepository.GetChildProperties(id);
            foreach (var childProperty in childPropertiesRepository)
            {
                var propertyNode = new TreeNode
                {
                    Text = childProperty.Name,
                    Name = $"{childProperty.Id}|Property"
                };

                //свойство в список дочерних свойств
                childProperties.Add(propertyNode);
            }
            return childProperties;
        }
    }
}