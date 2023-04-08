export default async function getAllActors() {
    const data = await fetch("https://localhost:7027/api/Actors/GetAll");
    
    return data.json();
}

export async function sendActor(obj) {
    const data = await fetch("https://localhost:7027/api/Actors", {
        method: 'POST',
        body: JSON.stringify({
            name:obj.name,
            profilePictureURL:obj.img,
            bio:obj.bio,
            movies:obj.movies
        }),
        headers: {
          'Content-Type': 'application/json'
        }
      });

    return data.json();
}