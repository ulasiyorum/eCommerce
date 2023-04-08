import { useEffect, useState } from "react";
import AdminNavbar from "../src/Components/AdminNavbar";
import Navbar from "../src/Components/Navbar";
import { getAllMovies } from "../src/lib/movies";


export default function HomePage({user,setUser,setAddState}) {
  
  const [movies, setMovies] = useState(null);
  
  useEffect(() => {
    async function fetchMovies() {
      const data = await getAllMovies();
      setMovies(data.data);
    }

    fetchMovies();
  },[]);

    return (
        <div className="flex flex-row">
        <Navbar user={user} setUser={setUser}/>
        <div className="flex flex-col">
        {
          user.username == "admin" ?
          (
            <AdminNavbar setAddState={setAddState}/>
          ) : (
            <></>
          )
        }
        {
          !movies ? (<div>Loading...</div>) : 
          (
          movies.map((mov,index) => {
            return <MovieCard key={mov.title + index} title={mov.title} img={mov.imageURL} price={mov.price}/>
          })
          )
        }
        </div>
      </div>
    );
}

function MovieCard({title,img,price}) {

  return(
    <div className="w-20 h-20 flex flex-col">
      <img src={img}/>
      <h1>{title}</h1>
      <h1>{price + "$"}</h1>
    </div>
  );
}