import { useEffect, useState } from "react";
import Dropdown from "../src/Components/Dropdown";
import Unauthorized from "../src/Components/Unauthorized";

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
    return(
        <div className="w-screen h-screen flex">
            <div className="flex flex-col m-auto">
                <h1 className="my-4 mx-auto">Genre:</h1>
                <Dropdown options={['Cinema','Actor','Movie','Producer']}/>
            </div>
        </div>
    );
}