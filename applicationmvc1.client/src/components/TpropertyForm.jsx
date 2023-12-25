import React, { useState, useEffect } from 'react';

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
    closeForm();
  }

  const addProperty = () => {
    // const newTproperty = {
    //   Name: formData.Name,
    //   Value: formData.Value,
    //   GroupId: selectedNode.Id, // id родителя
    //   Group: null
    // };
  
    // fetch('https://localhost:7070/api/Tproperty', {
    //   method: 'POST',
    //   headers: {
    //     'Content-Type': 'application/json',
    //   },
    //   body: JSON.stringify(newTproperty),
    // })
    //   .then((response) => response.json())
    //   .then((data) => {
    //     onAdd(data);
    //     setFormData({
    //       Name: '',
    //       Value: '',
    //       GroupId: '',
    //     });
    //   })
    //   .catch((error) => {
    //     console.error('Error adding Tproperty:', error);
    //     error.response.json().then((errorData) => {
    //       console.error('Server error details:', errorData);
    //     });
    //   });
  };

  const editProperty = async () => {
    try {
      console.log("Редактирование группы")
    } catch (error) {
      console.error('Произошла ошибка при редактировании:', error);
    }
  };

  const deleteProperty = async () => {
    try {
      console.log("Удаление группы")
    } catch (error) {
      console.error('Произошла ошибка при удалении:', error);
    }
  };

  const handleCancel = () => {
    setFormData({
      Name: '',
      Value: '',
      GroupId: '',
    });
    closeForm();
  };

  return (
    <div>
      <h2>Форма редактирования свойства</h2>
      <div style={{ marginBottom: '10px' }}>
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
      <div style={{ marginBottom: '10px' }}>
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
        <button type="button" onClick={handleCancel} style={{ marginLeft: '10px' }}>
          Отмена
        </button>
      </div>
    </div>
  );
};

export default TpropertyForm;


// useEffect(() => {
  //   if (groupId) {
  //     setFormData((prevData) => ({ ...prevData, GroupId: groupId }));
  //   }
  // }, [groupId]);