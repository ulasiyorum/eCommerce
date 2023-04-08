import { useEffect, useState } from "react";
import Dropdown from "../src/Components/Dropdown";
import Unauthorized from "../src/Components/Unauthorized";
import getAllGenres from "../src/lib/genres";
import Input from "../src/Components/Input";
import CheckboxList from "../src/Components/CheckboxList";
import getAllActors, { sendActor } from "../src/lib/actors";
import getAllProducers, { sendProducer } from "../src/lib/producers";
import getAllCinemas, { sendCinema } from "../src/lib/cinemas";
import addMovie, { getAllMovies } from "../src/lib/movies";



export default function AddForm({user,addState}) {

    const [form,setForm] = useState({});

    return user.username != "admin" ? ( 
        <Unauthorized/>
    ) : (
        addState == "movie" ?
        <AddMovie form={form} setForm={setForm}/>
        : addState == "producer" ? (
        <AddProducer form={form} setForm={setForm}/>   
        ) : addState == "actor" ? (<AddActor form={form} setForm={setForm}/>) : addState == "cinema" ? (<AddCinema form={form} setForm={setForm}/>) : (<div>404</div>)
    );
}

function AddMovie({form,setForm}) {

    const [genres,setGenres] = useState(null);
    const [actors, setActors] = useState(null);
    const [producers, setProducers] = useState(null);
    const[cinemas,setCinemas] = useState(null);
    useEffect(() => {
    const getGenres = async () => {
        const _genres = await getAllGenres();

        let newGenres = [];
        _genres.forEach((value) => {
            newGenres.push(value.genreName);
        });
        setGenres(newGenres);
    }



    const getActors = async () => {
        const _actors = await getAllActors();
        setActors(_actors.data);
    }
    const getProducers = async () => {
        const _producers = await getAllProducers();
        setProducers(_producers.data);
    }
    const getCinemas = async () => {
        const _cinemas = await getAllCinemas();
        setCinemas(_cinemas.data);
    }
    getCinemas();
    getProducers();
    getActors();
    getGenres();
    },[]);
    const producerNames = [];
    const cinemaNames = [];
    const actorNames = [];
    if(producers != null)
    producers.forEach((value) => {
        producerNames.push(value.name);
    });
    if(cinemas != null)
    cinemas.forEach((value) => {
        cinemaNames.push(value.name);
    });
    if(actors != null)
    actors.forEach((value) => {
        actorNames.push(value.name);
    });

    const sendForm = () => {
        addMovie(form);
    }
    return !genres || !actors || !producers || !cinemas ? (<div>Loading..</div>) : (
        <div className="w-screen h-screen flex flex-row">
            <div className="m-auto">
                <div className="w-1/2">
                <h1 className="my-4 mx-auto">Movie Name:</h1>
                <Input type="title" setForm={setForm}/>
                </div>
                <div>
                <h1 className="my-4 mx-auto">Movie Description:</h1>
                <Input type="desc" setForm={setForm}/>
                </div>
                <div>
                <h1 className="my-4 mx-auto">Movie Image:</h1>
                <Input type="img" setForm={setForm}/>
                </div>
                <div>
                <h1 className="my-4 mx-auto">Movie Price:</h1>
                <Input type="price" variant="number" setForm={setForm}/>
                </div>
                <div>
                        <h1 className="my-4 mx-auto">Select Genre:</h1>
                        <Dropdown idNameList={genres} setForm={setForm} type="genres" options={genres}/>
                </div>
            </div>
            <div className="m-auto">
                <div className="m-auto">
                    <div>
                        <h1 className="my-4 mx-auto">Producer:</h1>
                        <Dropdown idNameList={producers} type="producer" setForm={setForm} options={producerNames}/>
                    </div>
                    <div>
                        <h1 className="my-4 mx-auto">Cinemas:</h1>
                        <Dropdown idNameList={cinemas} type="cinema" setForm={setForm} options={cinemaNames}/>
                    </div>
                    <div>
                        <h1 className="my-4 mx-auto">Select Actors:</h1>
                        <CheckboxList type="actors" valueIdNames={actors} setForm={setForm} values={actorNames}/>
                    </div>
                </div>
            </div>
            <div className="m-auto">
                <button onClick={sendForm} className="text-white border-solid border-black border-2 bg-[#1B9688] rounded-md">Add</button>
            </div>
        </div>
    );
}

function AddProducer({form,setForm}) {

    const [movies,setMovies] = useState(null);

    useEffect(() => {
        const fetchMovies = async () => {
            const data = await getAllMovies();
            setMovies(data.data);
        }

        fetchMovies();
    },[]);

    const sendForm = () => {
        sendProducer(form);
    }

    const movieNames = [];
    if(movies != null)
    movies.forEach((val) => {
        movieNames.push(val.name);
    });

    return (
        <div className="w-screen h-screen flex flex-row">
            <div className="m-auto">
                <div className="my-4">
                <h1>Producer Name:</h1>
                <Input form={form} type="name" setForm={setForm}/>
                </div>
                <div className="my-4">
                <h1>Picture URL:</h1>
                <Input form={form} type="img" setForm={setForm}/>
                </div>
                <div className="my-4">
                <h1>Bio:</h1>
                <Input form={form} type="bio" setForm={setForm}/>
                </div>
                <div>
                <h1 className="my-4 mx-auto">Movies Produced:</h1>
                <CheckboxList type="genres" valueIdNames={movies}  setForm={setForm} values={movieNames}/>
                </div>
                <button onClick={sendForm} className="text-white border-solid border-black border-2 bg-[#1B9688] rounded-md">Add</button>
            </div>
        </div>
    );
}

function AddActor({form,setForm}) {

    const [movies,setMovies] = useState(null);

    useEffect(() => {
        const fetchMovies = async () => {
            const data = await getAllMovies();
            setMovies(data.data);
        }

        fetchMovies();
    },[]);


    const sendForm = () => {
        sendActor(form);
    }

    const movieNames = [];
    if(movies != null)
    movies.forEach((val) => {
        movieNames.push(val.name);
    });

    return (
        <div className="w-screen h-screen flex flex-row">
            <div className="m-auto">
                <div className="my-4">
                <h1>Actor Name:</h1>
                <Input form={form} type="name" setForm={setForm}/>
                </div>
                <div className="my-4">
                <h1>Picture URL:</h1>
                <Input form={form} type="img" setForm={setForm}/>
                </div>
                <div className="my-4">
                <h1>Bio:</h1>
                <Input form={form} type="bio" setForm={setForm}/>
                </div>
                <div>
                <h1 className="my-4 mx-auto">Movies Acted:</h1>
                <CheckboxList type="movies" valueIdNames={movies} setForm={setForm} values={movieNames}/>
                </div>
                <button onClick={sendForm} className="text-white border-solid border-black border-2 bg-[#1B9688] rounded-md">Add</button>
            </div>
        </div>
    );
}

function AddCinema({form,setForm}) {

    const [movies,setMovies] = useState(null);

    useEffect(() => {
        const fetchMovies = async () => {
            const data = await getAllMovies();
            setMovies(data.data);
        }

        fetchMovies();
    },[]);
    
    const sendForm = () => {
        sendCinema(form);
    }
    const movieNames = [];
    if(movies != null)
    movies.forEach((val) => {
        movieNames.push(val.name);
    });

    return (
        <div className="w-screen h-screen flex flex-row">
            <div className="m-auto">
                <div className="my-4">
                <h1>Cinema Name:</h1>
                <Input form={form} type="name" setForm={setForm}/>
                </div>
                <div className="my-4">
                <h1>Picture URL:</h1>
                <Input form={form} type="img" setForm={setForm}/>
                </div>
                <div className="my-4">
                <h1>Service Rate</h1>
                <Input form={form} type="rate" variant="number" setForm={setForm}/>
                </div>
                <div>
                <h1 className="my-4 mx-auto">Movies On Show:</h1>
                <CheckboxList type="genres" valueIdNames={movies} setForm={setForm} values={movieNames}/>
                </div>
                <button onClick={sendForm} className="text-white border-solid border-black border-2 bg-[#1B9688] rounded-md">Add</button>
            </div>
        </div>
    );
}


