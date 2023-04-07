import { useState } from "react";
import Navbar from "./Components/Navbar"

function App() {
  const [user, setUser] = useState(null);
  return (
    <>
      <Navbar user={user} setUser={setUser}/>
      {
        user.username == "admin" ?
        (
          <>
          <AdminNavbar/>
          </>
        ) : (
          <></>
        )
      }
    </>
  )
}

export default App
