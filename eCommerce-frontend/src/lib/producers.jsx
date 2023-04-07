export default async function getAllProducers() {
    const data = await fetch("https://localhost:7027/api/Producers/GetAll");
    
    return data.json();
}