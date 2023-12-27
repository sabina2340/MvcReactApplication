import React, { useState } from 'react';

const Menu = ({
  selectedNode,
  setActiveForm,
  setActiveAction
}) => {
  const [isAddMenuOpen, setIsAddMenuOpen] = useState(false);

  const toggleAddMenu = () => {
    setIsAddMenuOpen(!isAddMenuOpen);
  };

  // добавить группу мы можем только к группе(не можем к свойству)
  // добавить свойство можно только к группе(не можем к свойству)
  const handleAddGroupClick = () => {
    if(selectedNode.type === "Group"){
        setActiveForm('Tgroup');
        setActiveAction('Add');
    }
  };
  const handleAddPropertyClick = () => {
    if(selectedNode.type === "Group"){
        setActiveForm('Tproperty');
        setActiveAction('Add');
    }
  };

  const handleOnEditClick = () => {
    if(selectedNode.type === "Group"){
        setActiveForm('Tgroup');
        setActiveAction('Edit');
    }
    if(selectedNode.type === "Property"){
        setActiveForm('Tproperty');
        setActiveAction('Edit');
    }
  };

  const handleOnDeleteClick = () => {
    if(selectedNode.type === "Group"){
        setActiveForm('Tgroup');
        setActiveAction('Delete');
    }
    if(selectedNode.type === "Property"){
        setActiveForm('Tproperty');
        setActiveAction('Delete');
    }
  };
  return (
    <div>
      <h1>Меню</h1>
      <ul style={{ display: 'flex', listStyleType: 'none', padding: 0 }}>
        <li style={{ marginRight: '10px' }} onClick={toggleAddMenu}>
          Добавить
          {isAddMenuOpen && (
            <ul style={{ listStyleType: 'none', paddingLeft: 0, marginTop: '5px' }}>
              <li onClick={handleAddGroupClick} style={{ marginRight: '10px' }}>Группу</li>
              <li onClick={handleAddPropertyClick}>Свойство</li>
            </ul>
          )}
        </li>
        <li style={{ marginRight: '10px' }} onClick={handleOnEditClick}>Редактировать</li>
        <li onClick={handleOnDeleteClick}>Удалить</li>
      </ul>
      <div>
        <strong>Selected Node:</strong> {selectedNode ? selectedNode.name : 'None'}
      </div>
      <div>
        <strong>Group ID:</strong> {selectedNode ? selectedNode.id : 'None'}
      </div>
    </div>
  );
};

export default Menu;