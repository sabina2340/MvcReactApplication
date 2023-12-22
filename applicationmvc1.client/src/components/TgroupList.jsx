import React, { useState, useEffect } from 'react';

const TgroupList = () => {
  const [groups, setGroups] = useState([]);

  useEffect(() => {
    // Replace the Axios call with the fetch API
    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:7070/api/Tgroup');
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();
        setGroups(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, []);

  return (
    <div>
      <h1>Groups</h1>
      <ul>
        {groups.map((group) => (
          <li key={group.id}>{group.name}</li>
        ))}
      </ul>
    </div>
  );
};

export default TgroupList;
