import "./Home.css";
import React, { useState, useEffect } from 'react';

const ApiData = () => {
  const [apiData, setApiData] = useState(null);

  useEffect(() => {
    // Component yüklendiğinde API'den veri çekmek için kullanılır
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5105/api/Home');
        const data = await response.json();
        setApiData(data);
      } catch (error) {
        console.error('API isteği başarısız:', error);
      }
    };

    fetchData(); // fetchData fonksiyonunu çağırarak API'den veriyi çekin
  }, []); // Boş dependency array ile sadece bir kez çalışmasını sağlayın

  return (
    <div>
      <h1>API Verisi:</h1>
      {apiData ? (
        <p>{apiData.message}</p>
      ) : (
        <p>API verisi yükleniyor...</p>
      )}
    </div>
  );
};

export default ApiData;