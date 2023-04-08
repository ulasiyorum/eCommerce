export default async function getAllProducers() {
    const data = await fetch("https://localhost:7027/api/Producers/GetAll");
    
    return data.json();
}

export async function sendProducer(obj) {
    const data = await fetch("https://localhost:7027/api/Producers", {
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