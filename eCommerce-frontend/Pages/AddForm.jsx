import { useEffect, useState } from "react";
import Dropdown from "../src/Components/Dropdown";
import Unauthorized from "../src/Components/Unauthorized";
import getAllGenres from "../src/lib/genres";
import Input from "../src/Components/Input";
import CheckboxList from "../src/Components/CheckboxList";
import getAllActors from "../src/lib/actors";
import getAllProducers from "../src/lib/producers";
import getAllCinemas from "../src/lib/cinemas";

export default function AddForm({user,addState}) {

    const [form,setForm] = useState({});

    return user.username == "admin" ? ( 
        <Unauthorized/>
    ) : (
        addState == "movie" ?
        <div>Hi</div>
        : (
            <AddMovie form={form} setForm={setForm}/>
        )
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
                        <h1 className="my-4 mx-auto">Select Genres:</h1>
                        <CheckboxList setForm={setForm} type="genres" values={genres}/>
                </div>
            </div>
            <div className="m-auto">
                <div className="m-auto">
                    <div>
                        <h1 className="my-4 mx-auto">Producer:</h1>
                        <Dropdown type="producer" setForm={setForm} options={producerNames}/>
                    </div>
                    <div>
                        <h1 className="my-4 mx-auto">Cinemas:</h1>
                        <Dropdown type="cinema" setForm={setForm} options={cinemaNames}/>
                    </div>
                    <div>
                        <h1 className="my-4 mx-auto">Select Actors:</h1>
                        <CheckboxList type="genres" setForm={setForm} values={actorNames}/>
                    </div>
                </div>
            </div>
            <div className="m-auto">
                <button className="text-white border-solid border-black border-2 bg-[#1B9688] rounded-md">Add</button>
            </div>
        </div>
    );
}