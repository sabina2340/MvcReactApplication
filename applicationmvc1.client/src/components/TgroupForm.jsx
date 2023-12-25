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

      setFormData({
        Name: '',
      });
    } catch (error) {
      console.error('Произошла ошибка:', error);
    }
  };

  const editGroup = async () => {
    try {
      console.log("Редактирование группы")
    } catch (error) {
      console.error('Произошла ошибка при редактировании:', error);
    }
  };

  const deleteGroup = async () => {
    try {
      console.log("Удаление группы")
    } catch (error) {
      console.error('Произошла ошибка при удалении:', error);
    }
  };


  return (
    <div>
      <h2>Форма редактирования группы</h2>
      <div style={{ marginBottom: '10px' }}>
        <label>
          ID:
          <input
            type="text"
            placeholder="ID"
            value={formData.id}
            onChange={(e) => setFormData({ ...formData, id: e.target.value })}
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