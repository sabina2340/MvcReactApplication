// import React, { useState, useEffect } from 'react';

// const TgroupList = () => {
//   const [tgroups, setTgroups] = useState([]);
//   const [error, setError] = useState(null);

//   useEffect(() => {
//     fetch('https://localhost:7070/api/Tgroup')
//       .then(response => {
//         if (!response.ok) {
//           throw new Error('Network response was not ok');
//         }
//         return response.json();
//       })
//       .then(data => {
//         setTgroups(data);
//       })
//       .catch(error => setError(error.message));
//   }, []);
  

//   if (error) {
//     return <div>Error: {error}</div>;
//   }

//   return (
//     <div>
//       <h2>Tgroup List</h2>
//       <ul>
//         {tgroups.map(tgroup => (
//           <li key={tgroup.id}>{tgroup.name}</li>
//         ))}
//       </ul>
//     </div>
//   );
// };

// export default TgroupList;
