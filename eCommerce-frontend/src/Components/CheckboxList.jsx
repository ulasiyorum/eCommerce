import { useEffect, useState } from "react";

function CheckboxList({ values,setForm,type }) {
  const [checkedItems, setCheckedItems] = useState([]);

  const handleCheckboxChange = (event) => {
        if(!checkedItems.includes(event.target.name))
        {
            setCheckedItems([...checkedItems,event.target.name]);
        }
        else
            setCheckedItems(checkedItems.filter((val) => val !== event.target.name));    
    };

    useEffect(() => {
        setForm((prevForm) => {
            return {...prevForm,[`${type}`]:checkedItems}
        });
    },[checkedItems]);

  return (
    <div className="grid grid-cols-2">
      {values.map((value, index) => (
        <label key={index} className="inline-flex mx-3 items-center mt-3">
          <input
            type="checkbox"
            name={value}
            onChange={handleCheckboxChange}
            className="form-checkbox h-5 w-5 text-blue-600"
          />
          <span className="ml-2 text-gray-700">{value}</span>
        </label>
      ))}
    </div>
  );
}

export default CheckboxList;




