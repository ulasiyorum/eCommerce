import { faBars } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function Navbar()
{

    return(
        <div className="flex">
            <div className="border-solid cursor-pointer border-[4px] absolute left-4 top-10 bg-[#D3FBE3] flex w-10 h-10 rounded-md border-[#7AE7BB]">
                <FontAwesomeIcon className="m-auto" icon={faBars} />
            </div>
            <Menu/>
        </div>
    );

}

function Menu() {
    return (
        <div className="absolute w-64 border-solid border-black drop-shadow-lg h-full bg-[#26AF92] -z-20">
            <div className="flex flex-col relative top-32">
                <div className="flex flex-col">
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center mx-4 my-4 border-solid border-2 rounded-md drop-shadow-md">Browse Movies</a>
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center mx-4 my-4 border-solid border-2 rounded-md drop-shadow-md">My Movies</a>
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center mx-4 my-4 border-solid border-2 rounded-md drop-shadow-md">Browse Actors</a>
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center mx-4 my-4 border-solid border-2 rounded-md drop-shadow-md">Browse Producers</a>
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center mx-4 my-4 border-solid border-2 rounded-md drop-shadow-md">Browse Cinemas</a>
                </div>
                <div>
                    <div className="flex flex-row my-8">
                        <button className="bg-[#137D7B] border-solid border-2 drop-shadow-sm text-slate-50 rounded-lg w-24 text-center h-12 m-auto">Register</button>
                        <button className="bg-[#137D7B] border-solid border-2 drop-shadow-sm text-slate-50 rounded-lg w-24 text-center h-12 m-auto">Log In</button>
                    </div>
                </div>
                <button className="bg-[#FF9605] border-solid border-2 drop-shadow-sm text-slate-50 rounded-lg w-24 text-center h-12 m-auto">Cart</button>
            </div>
        </div>
    );
}