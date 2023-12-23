import React, { useState, useEffect } from 'react';
import TreeNode from './TreeNode';

const Tree = () => {
  const [rootNode, setRootNode] = useState(null);

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
  }, []); // можно убрать [], чтобы каждую секунду исходил запрос

  return (
    <div>
      <h1>Tree</h1>
      {rootNode && <TreeNode node={rootNode} />}
    </div>
  );
};

export default Tree;
