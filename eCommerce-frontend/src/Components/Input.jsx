import { useEffect, useState } from "react";

export default function Input({setForm,type,variant}) {
    const [value,setValue] = useState('');

    useEffect(() => {
        setForm((prevForm) => {
            return {...prevForm,[`${type}`]:value}
        });
        
    },[value]);

    const handleKeyPress = (event) => {
        if(variant != "number")
            return;
        const charCode = event.which ? event.which : event.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
          event.preventDefault();
        }
      }

    return (
        <div className="flex flex-col">
          <input
            type="text" onChange={(event) => setValue(event.target.value)} value={value}
            onKeyDown={handleKeyPress}
            className="border-gray-400 border-2 rounded-md py-2 px-3 focus:outline-none focus:border-blue-500"
          />
        </div>
      );
}