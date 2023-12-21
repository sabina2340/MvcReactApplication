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

        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;
        }

        public TreeNode GetTree()
        {
            //// Получите корневой элемент из Tgroup
            //var rootGroup = _treeRepository.GetRootGroup();

            //// Создайте корневой узел для дерева
            //var rootNode = new TreeNode
            //{
            //    Text = rootGroup.Name,
            //    Name = $"{rootGroup.Id}|Group"
            //};

            //// Рекурсивно добавьте дочерние узлы
            //AddChildNodes(rootNode);

            //return rootNode;
            return new TreeNode();
        }

        private void AddChildNodes(TreeNode parentNode)
        {
            //// Получите дочерние группы из базы данных по parentId
            //var childGroups = _treeRepository.GetChildGroups(parentNode.Id);

            //foreach (var childGroup in childGroups)
            //{
            //    var childNode = new TreeNode
            //    {
            //        Text = childGroup.Name,
            //        Name = $"{childGroup.Id}|Group"
            //    };

            //    // Рекурсивно добавьте дочерние узлы для текущей группы
            //    AddChildNodes(childNode);

            //    // Добавьте дочерний узел к родительскому узлу
            //    //parentNode.Children.Add(childNode);
            //}

            // Получите свойства (Tproperty) для текущей группы
            //var properties = _treeRepository.GetProperties(parentNode.Id);

            //foreach (var property in properties)
            //{
            //    var propertyNode = new TreeNode
            //    {
            //        Text = property.Name,
            //        Name = $"{property.Id}|Property"
            //    };

                // Добавьте узел свойства к родительскому узлу
                //parentNode.Children.Add(propertyNode);
            }
        
    }
}
