export default async function getAllGenres() {
    const data = await fetch("https://localhost:7027/Genres/GetAll");
    
    return data.json();
}