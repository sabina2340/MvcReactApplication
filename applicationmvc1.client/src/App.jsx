import React, { useState } from 'react';
import Tree from './components/Tree';

const App = () => {
  const [selectedNode, setSelectedNode] = useState(null);

  const handleNodeClick = (nodeData) => {
    // Обновляем стейт с информацией о выбранном узле
    setSelectedNode(nodeData);
  };

  return (
    <div>
      <Tree onNodeClick={handleNodeClick} />
      <div>
        <h2>Selected Node:</h2>
        {selectedNode ? (
          <div>
            <p><strong>Name:</strong> {selectedNode.name}</p>
            <p><strong>Text:</strong> {selectedNode.text}</p>
            <p><strong>ID:</strong> {selectedNode.id}</p>
            <p><strong>Type:</strong> {selectedNode.type}</p>
          </div>
        ) : (
          <p>No node selected</p>
        )}
      </div>
    </div>
  );
};

export default App;