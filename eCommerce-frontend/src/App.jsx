import { useEffect, useState } from "react";
import { Routes,Route, useNavigate } from "react-router-dom"
import HomePage from "../Pages/HomePage";
import AddForm from "../Pages/AddForm";

function App() {
  const [user, setUser] = useState({username:null});
  const [addState, setAddState] = useState("");
  const navigator = useNavigate();
  useEffect(() => {
    if(addState != "")
      navigator("/add");
  },[addState]);

  return (
    <Routes>
      <Route path="/" element={<HomePage user={user} setAddState={setAddState} setUser={setUser}/>}/>
      <Route path="/add" element={<AddForm user={user} addState={addState}/>}/>
    </Routes>
  );
}



export default App
