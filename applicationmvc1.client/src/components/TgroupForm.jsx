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
      // добавляем запись в таблицу tgroup
      const newTgroup = { ...formData };
      const response = await fetch('https://localhost:7070/api/Tgroup', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newTgroup),
      });

      if (response.ok) {
        // добавляем запись в таблицу trelation
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
      const Id = selectedNode.id
      const response = await fetch(`https://localhost:7070/api/Tgroup/${Id}`, {
        method: 'PUT',
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
      // удаляем запись в таблице tgroup
      const parentId = selectedNode.id
      const response = await fetch(`https://localhost:7070/api/Tgroup/${parentId}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
      });
      if (response.ok) {
        
        await fetch(`https://localhost:7070/api/Trelation/${parentId}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
        });
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
      <div>
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
      <div>
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
        <button type="button" onClick={handleCancel}>
          Отмена
        </button>
      </div>
    </div>
  );
};

export default TgroupForm;