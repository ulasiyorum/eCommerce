import { useEffect, useState } from "react";

function CheckboxList({ values,setForm,type,valueIdNames }) {
  const [checkedItems, setCheckedItems] = useState([]);

  const handleCheckboxChange = (event) => {
        if(!checkedItems.includes(findIdByName(event.target.name,valueIdNames)))
        {
            setCheckedItems([...checkedItems,findIdByName(event.target.name,valueIdNames)]);
        }
        else
            setCheckedItems(checkedItems.filter((val) => { val != findIdByName(event.target.name,valueIdNames)}));    
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

function findIdByName(name,idNameList) {

  let id = 0;
  idNameList.forEach(element => {
    if(element.name == name)
      id = element.id;
  });

  return id;
}

export default CheckboxList;




