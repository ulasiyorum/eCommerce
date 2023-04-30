import { useEffect, useState } from "react";
import AdminNavbar from "../Components/AdminNavbar";
import Navbar from "../Components/Navbar";
import { getAllMovies } from "../lib/movies";


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
        <div className="flex flex-col w-screen h-screen">
        {
          user.username == "admin" ?
          (
            <AdminNavbar setAddState={setAddState}/>
          ) : (
            <></>
          )
        }
        <div className="flex flex-wrap">
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
      </div>
    );
}

function MovieCard({title,img,price}) {

  return(
    <div className="flex flex-col" style={{margin:"10px"}}>
      <img style={{width:"300px",height:"500px",objectFit:"cover"}} className="rounded-lg block shadow-sm border-black border-2 overflow-hidden" src={img}/>
      <span className="mx-auto my-4 text-3xl">{title + " " + price + "$"}</span>
    </div>
  );
}