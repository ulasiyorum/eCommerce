export default async function login(name,pass) {
    const data = await fetch("https://localhost:7027/Auth/Login", {
        method: 'POST',
        body: JSON.stringify({
          username: name,
          password: pass
        }),
        headers: {
          'Content-Type': 'application/json'
        }
      });
    
    return data.json();
}