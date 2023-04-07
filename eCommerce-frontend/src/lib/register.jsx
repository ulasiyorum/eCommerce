export default async function register(name,pass) {
    
    const data = await fetch("https://localhost:7027/Auth/Register", {
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