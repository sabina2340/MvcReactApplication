import React, { useState, useEffect } from 'react';

const TreeNode = ({ node }) => {
   // Пустой массив зависимостей, чтобы запросы выполнялись только при монтировании компонента
  const [children, setChildren] = useState([]);

    // логика для того чтобы вытащить из node который состоит из text и name - id, type и тд
    const text = node.text;
    const parts = node.name.split("|");
    const id = parts[0];
    const type = parts[1];
    useEffect(() => {
      const fetchChildNodes = async () => {
        try {
          if (id) {
            const response = await fetch(`https://localhost:7070/api/Tree/GetChilds/${id}`);
            if (response.ok) {
              const data = await response.json();
              setChildren(data);
            } else {
              console.error('Error fetching child nodes:', response.statusText);
            }
          }
        } catch (error) {
          console.error('Error fetching child nodes:', error);
        }
      };
    
      // Загрузка дочерних элементов при монтировании компонента
      fetchChildNodes();
    }, [id]);
  
return (
    <div>
      <div>
        <strong>Name:</strong> {node.name}
      </div>
      <div>
        <strong>Text:</strong> {node.text}
      </div>
      {children.length > 0 && type !== "Property" && (  // если элемент Property, то не перебираем children
        <ul>
          {children.map((childNode, index) => (
            <li key={index}>
              <TreeNode node={childNode} />
            </li>
          ))}
        </ul>
      )}
      </div>
  );
};

export default TreeNode;