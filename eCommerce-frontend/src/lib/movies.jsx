export default async function addMovie(obj) {
    
    const data = await fetch("https://localhost:7027/api/Movies", {
        method: 'POST',
        body: JSON.stringify({
            title:obj.title,
            
        }),
        headers: {
          'Content-Type': 'application/json'
        }
      });

    return data.json();
}