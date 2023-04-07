export default async function getAllActors() {
    const data = await fetch("https://localhost:7027/api/Actors/GetAll");
    
    return data.json();
}