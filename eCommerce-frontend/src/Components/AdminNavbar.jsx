import { faSquarePlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
export default function AdminNavbar({setAddState}) {
    return (
        <div className="mx-auto flex h-20 w-[64rem]">
            <button className="m-auto" onClick={() => setAddState("movie")}>
                <FontAwesomeIcon className="m-auto" icon={faSquarePlus}/> Add Movies
            </button>
            <button className="m-auto" onClick={() => setAddState("producer")}>
                <FontAwesomeIcon className="m-auto" icon={faSquarePlus}/> Add Producers
            </button>
            <button className="m-auto" onClick={() => setAddState("actor")}>
                <FontAwesomeIcon className="m-auto" icon={faSquarePlus}/> Add Actors
            </button>
            <button className="m-auto" onClick={() => setAddState("cinema")}>
                <FontAwesomeIcon className="m-auto" icon={faSquarePlus}/> Add Cinemas
            </button>
        </div>
    )
}