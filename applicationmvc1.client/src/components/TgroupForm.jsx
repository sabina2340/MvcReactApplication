import React, { useState } from 'react';

const TgroupForm = ({ closeForm, selectedNode, activeAction }) => {
  const [formData, setFormData] = useState({
    Name: '',
  });

  const handleSave = () => {
    if (activeAction === "Add") {
      addGroup();
    }
    if (activeAction === "Edit") {
      editGroup();
    }
    if (activeAction === "Delete") {
      deleteGroup();
    }
    setFormData({
      Name: '',
    });
    closeForm();
  };

  const handleCancel = () => {
    setFormData({
      Name: '',
    });
    closeForm();
  };

  const addGroup = async () => {
    try {
      const newTgroup = { ...formData };
      const response = await fetch('https://localhost:7070/api/Tgroup', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newTgroup),
      });

      if (response.ok) {
        const responseData = await response.json();
        const newTrelation = {
          parentGroupId: selectedNode.id,
          childGroupId: responseData.id,
        };

        await fetch('https://localhost:7070/api/Trelation', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(newTrelation),
        });
      } else {
        console.error('Ошибка при добавлении свойства.');
      }
    } catch (error) {
      console.error('Произошла ошибка:', error);
    }
  };

  const editGroup = async () => {
    try {
      const editTgroup = { ...formData };
      const parentId = selectedNode.id
      const response = await fetch(`https://localhost:7070/api/Tgroup/${parentId}`, {
        method: 'PUT', // Используйте 'PATCH', если редактируете часть данных
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(editTgroup),
      });
      if (response.ok) {
        console.log('Группа успешно отредактирована');
      } else {
        console.error('Ошибка при редактировании группы:', response.status);
      }
    } catch (error) {
      console.error('Произошла ошибка при редактировании:', error);
    }
  };

  const deleteGroup = async () => {
    try {
      const parentId = selectedNode.id
      const response = await fetch(`https://localhost:7070/api/Tgroup/${parentId}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
      });
  
      if (response.ok) {
        console.log('Группа успешно удалена');
      } else {
        console.error('Ошибка при удалении группы:', response.status);
      }
    } catch (error) {
      console.error('Произошла ошибка при удалении:', error);
    }
  };


  return (
    <div>
      <h2>Форма редактирования группы</h2>
      <div style={{ marginBottom: '10px' }}>
        <label>
          parentID:
          <input
            type="text"
            placeholder="ID"
            value={selectedNode.id}
            readOnly
          />
        </label>
      </div>
      <div style={{ marginBottom: '10px' }}>
        <label>
          Наименование:
          <input
            type="text"
            placeholder="name"
            value={formData.Name}
            onChange={(e) => setFormData({ ...formData, Name: e.target.value })}
          />
        </label>
      </div>
      <div>
        <button type="button" onClick={handleSave}>
          Сохранить
        </button>
        <button type="button" onClick={handleCancel} style={{ marginLeft: '10px' }}>
          Отмена
        </button>
      </div>
    </div>
  );
};

export default TgroupForm;