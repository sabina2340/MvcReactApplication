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
        // дерево в виде списка узлов
        List<TreeNode> tree;

        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;

        }

        public List<TreeNode> GetTree()
        {
            tree = new List<TreeNode>();
            // Получите корневой элемент из Tgroup
            var rootGroup = _treeRepository.GetRootGroup();

            // Создайте корневой узел для дерева
            var rootNode = new TreeNode
            {
                Text = rootGroup.Name,
                Name = $"{rootGroup.Id}|Group"
            };
            // добавим его в список узлов дерева
            tree.Add(rootNode);

            // Рекурсивно добавьте дочерние узлы корня
            AddChildNodes(rootNode);

            return tree;
        }

        private void AddChildNodes(TreeNode parentNode)
        {
            int id = -1;
            string name;

            string inputString = parentNode.Name; // по типу: "123|Group"
            // cчитываем id и тип(Group/Property)
            try
            {
                string[] parts = inputString.Split('|');

                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out id))
                    {
                        name = parts[1];
                    }
                    else
                    {
                        throw new FormatException("Не удалось преобразовать число.");
                    }
                }
                else
                {
                    throw new FormatException("Строка не соответствует ожидаемому формату.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            // Получите дочерние группы из базы данных по parentId
            var childGroups = _treeRepository.GetChildGroups(id);
            //Получите свойства(Tproperty) для текущей группы
            var childProperties = _treeRepository.GetProperties(id);

            foreach (var childGroup in childGroups)
            {
                var childNode = new TreeNode
                {
                    Text = childGroup.Name,
                    Name = $"{childGroup.Id}|Group"
                };

                // Рекурсивно добавляем дочерние узлы для текущей группы
                AddChildNodes(childNode);

                // добавим в список узлов узел группы
                tree.Add(childNode);
            }
            foreach (var property in childProperties)
            {
                var propertyNode = new TreeNode
                {
                    Text = property.Name,
                    Name = $"{property.Id}|Property"
                };

                // Добавим в список узлов узел свойство
                tree.Add(propertyNode);
            }
        }
        
    }
}
