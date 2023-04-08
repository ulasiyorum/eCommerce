export default async function getAllCinemas() {
    const data = await fetch("https://localhost:7027/api/Cinemas/GetAll");
    
    return data.json();
}

export async function sendCinema(obj) {
    const data = await fetch("https://localhost:7027/api/Cinemas", {
        method: 'POST',
        body: JSON.stringify({
            name:obj.name,
            cinemaLogo:obj.img,
            serviceRate:obj.rate,
            movies:obj.movies
        }),
        headers: {
          'Content-Type': 'application/json'
        }
      });

    return data.json();
}