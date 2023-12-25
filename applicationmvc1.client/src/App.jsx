import React, { useState } from 'react';
import Menu from './components/Menu';
import Tree from './components/Tree';
import TgroupForm from './components/TgroupForm';
import TpropertyForm from './components/TpropertyForm';

const App = () => {
  const [selectedNode, setSelectedNode] = useState("");
  const [activeForm, setActiveForm] = useState("");
  const [activeAction, setActiveAction] = useState("");

  const handleNodeClick = (nodeData) => {
    setSelectedNode(nodeData);
  };

  const handleCloseForms = () => {
    setActiveForm("");
    setActiveAction("");
  };

  return (
    <div>
      <div style={{ marginRight: '20px' }}>
        <Menu
          selectedNode={selectedNode}
          setActiveForm={setActiveForm}
          setActiveAction={setActiveAction}
        />
      </div>

      <Tree onNodeClick={handleNodeClick} />

      <div>
        {activeForm === 'Tproperty' && selectedNode !== null && activeAction !== null && (
          <TpropertyForm
            closeForm={handleCloseForms}
            selectedNode={selectedNode}
            activeAction={activeAction}
          />  
        )}
      </div>
      <div>
        {activeForm === 'Tgroup' && selectedNode !== null && activeAction !== null && (
          <TgroupForm 
            closeForm={handleCloseForms}
            selectedNode={selectedNode}
            activeAction={activeAction}
          />
        )}
      </div>
    </div>
  );
};

export default App;
