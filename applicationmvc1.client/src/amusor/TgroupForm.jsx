// import React, { useState } from 'react';

// const TgroupForm = ({ onAdd }) => {
//   const [name, setName] = useState('');

//   const handleAdd = () => {
//     const newTgroup = { name };
//     fetch('https://localhost:7070/api/Tgroup', {
//       method: 'POST',
//       headers: {
//         'Content-Type': 'application/json',
//       },
//       body: JSON.stringify(newTgroup),
//     })
//       .then(response => response.json())
//       .then(data => onAdd(data));
//   };

//   return (
//     <div>
//       <h2>Tgroup Form</h2>
//       <input
//         type="text"
//         placeholder="Name"
//         value={name}
//         onChange={e => setName(e.target.value)}
//       />
//       <button onClick={handleAdd}>Add Tgroup</button>
//     </div>
//   );
// };

// export default TgroupForm;
