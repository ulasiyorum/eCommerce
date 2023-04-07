export default async function getAllCinemas() {
    const data = await fetch("https://localhost:7027/api/Cinemas/GetAll");
    
    return data.json();
}