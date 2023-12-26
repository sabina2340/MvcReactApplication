import React, { useState } from 'react';

const TpropertyForm = ({ closeForm, selectedNode, activeAction }) => {
  const [formData, setFormData] = useState({
    Name: '',
    Value: '',
    GroupId: '',
  });

  const handleSave = () => {
    if (activeAction === "Add") {
      addProperty();
    }
    if (activeAction === "Edit") {
      editProperty();
    }
    if (activeAction === "Delete") {
      deleteProperty();
    }
    setFormData({
      Name: '',
      Value: '',
      GroupId: '',
    });
    closeForm();
  }

  const handleCancel = () => {
    setFormData({
      Name: '',
      Value: '',
      GroupId: '',
    });
    closeForm();
  };

  const addProperty = async () => {
    try {
      const newTproperty = {
        Name: formData.Name,
        Value: formData.Value,
        GroupId: selectedNode.id
      };

      console.log("New Tproperty:", newTproperty);

      const response = await fetch('https://localhost:7070/api/Tproperty', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newTproperty),
      });
      if (response.ok) {
        console.log("свойство добавлено");
      } else {
        console.error('Ошибка при добавлении свойства:', response.statusText);
      }
    } catch (error) {
      console.error('Произошла ошибка:', error);
    }
  };
  
  const editProperty = async () => {
    try {
      const editedTproperty = {
        Name: formData.Name,
        Value: formData.Value,
      };
      const Id = selectedNode.id;
      const response = await fetch(`https://localhost:7070/api/Tproperty/${Id}`, {
        method: 'PATCH', // Используйте 'PATCH', если редактируете часть данных
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(editedTproperty),
      });
      if (response.ok) {
        // Добавьте здесь логику для обновления дерева
        // Например, вызовите функцию, которая обновляет дерево
        // updateTree(selectedNode.ParentId);
        console.log('Свойство успешно отредактировано');
      } else {
        console.error('Ошибка при редактировании свойства:', response.status);
      }
    } catch (error) {
      console.error('Произошла ошибка при редактировании:', error);
    }
  };
  
  const deleteProperty = async () => {
    try {
      // удаляем запись в таблице tproperty
      const Id = selectedNode.id
      const response = await fetch(`https://localhost:7070/api/Tproperty/${Id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
      });
      if (response.ok) {
        // После успешного удаления свойства вызывайте функцию обновления дерева
        // updateTree(selectedNode.ParentId);
        console.log('Свойство успешно удалено');
      } else {
        console.error('Ошибка при удалении свойства:', response.status);
      }
    } catch (error) {
      console.error('Произошла ошибка при удалении:', error);
    }
  };

  return (
    <div>
      <h2>Форма редактирования свойства</h2>
      <div>
        <label>
          Наименование:
          <input
            type="text"
            name="name"
            placeholder="Наименование"
            value={formData.Name}
            onChange={(e) => setFormData({ ...formData, Name: e.target.value })}
          />
        </label>
      </div>
      <div>
        <label>
          Значение:
          <input
            type="text"
            name="value"
            placeholder="Значение"
            value={formData.Value}
            onChange={(e) => setFormData({ ...formData, Value: e.target.value })}
          />
        </label>
      </div>
      <div>
        <button type="button" onClick={handleSave}>
          Сохранить
        </button>
        <button type="button" onClick={handleCancel}>
          Отмена
        </button>
      </div>
    </div>
  );
};

export default TpropertyForm;