import React, { useState, useEffect } from 'react';

const Tree = ({ onNodeClick }) => {
  // корень
  const [rootNode, setRootNode] = useState(null);
  // вытаскиваем корень
  useEffect(() => {
    const fetchRootNode = async () => {
      try {
        const response = await fetch(`https://localhost:7070/api/Tree/GetRoot`);
        if (response.ok) {
          const data = await response.json();
          setRootNode(data);
        } else {
          console.error('Error fetching root node:', response.statusText);
        }
      } catch (error) {
        console.error('Error fetching root node:', error);
      }
    };

    fetchRootNode();
  }, []); 
  
  const TreeNode = ({ node }) => {
    // Пустой массив зависимостей, чтобы запросы выполнялись только при монтировании компонента
    const [children, setChildren] = useState([]);
    
    // логика для того чтобы вытащить из node который состоит из text и name - id, type и тд
    const text = node.text;
    const parts = node.name.split("|");
    const id = parts[0];
    const type = parts[1];
    
    // если нажали на узел, то
    const handleNodeClick = () => {
      // Вызывает функцию из контейнера, передавая данные об узле
      onNodeClick({ id, type, text, name: node.name });
    };

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

      fetchChildNodes();
    }, []);
    
    return (
        <div>
          <div onClick={handleNodeClick}>
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
////////////////
  return (
    <div>
      {rootNode && <TreeNode node={rootNode}/>}
    </div>
  );
};

export default Tree;


