export default async function addMovie(obj) {
  console.log(obj);
    const data = await fetch("https://localhost:7027/api/Movies", {
        method: 'POST',
        body: JSON.stringify({
            title:obj.title,
            imageURL:obj.img,
            description:obj.desc,
            price:obj.price,
            genre:obj.genres,
            datePublished:Date.now,
            actors:obj.actors,
            cinemaId:obj.cinema,
            producerId:obj.producer
        }),
        headers: {
          'Content-Type': 'application/json'
        }
      });
      console.log(data);
    return data.json();
}

export async function getAllMovies() {
  const data = await fetch("https://localhost:7027/api/Movies/GetAll");
    
  return data.json();
}