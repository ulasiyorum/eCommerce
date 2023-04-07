import { faBars } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Modal, { RegisterModal } from "./Dialog";
import { useState } from "react";

export default function Navbar({user,setUser})
{
    
    return(
        <div className="flex flex-col w-64 border-solid border-black drop-shadow-lg h-screen bg-[#26AF92] px-4">
            <div className="border-solid cursor-pointer absolute border-[4px] left-4 top-10 bg-[#D3FBE3] flex w-10 h-10 rounded-md border-[#7AE7BB]">
                <FontAwesomeIcon className="m-auto" icon={faBars} />
            </div>
            <Menu user={user} setUser={setUser}/>
        </div>
    );

}

function Menu({user,setUser}) {
    
    return (
        <div className="my-40">
            <div className="flex flex-col">
                <div className="flex flex-col">
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center  my-4 border-solid border-2 rounded-md drop-shadow-md">Browse Movies</a>
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center  my-4 border-solid border-2 rounded-md drop-shadow-md">My Movies</a>
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center  my-4 border-solid border-2 rounded-md drop-shadow-md">Browse Actors</a>
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center  my-4 border-solid border-2 rounded-md drop-shadow-md">Browse Producers</a>
                    <a className="cursor-pointer bg-[#1B9688] text-white text-center  my-4 border-solid border-2 rounded-md drop-shadow-md">Browse Cinemas</a>
                </div>
                <div>
                    <div className="flex flex-row my-8">
                        {
                        user == null ? (
                        <>
                        <RegisterModal setUser={setUser} className="bg-[#137D7B] border-solid border-2 drop-shadow-sm text-slate-50 rounded-lg w-24 text-center h-12 m-auto">Register</RegisterModal>
                        <Modal setUser={setUser} className="bg-[#137D7B] border-solid border-2 drop-shadow-sm text-slate-50 rounded-lg w-24 text-center h-12 m-auto">Log In</Modal>
                        </>) : (<div className="text-white mx-auto">{"Welcome " + user.username}</div>)
                        }
                    </div>
                </div>
                <button className="bg-[#FF9605] border-solid border-2 drop-shadow-sm text-slate-50 rounded-lg w-24 text-center h-12 m-auto">Cart</button>
            </div>
        </div>
    );
}