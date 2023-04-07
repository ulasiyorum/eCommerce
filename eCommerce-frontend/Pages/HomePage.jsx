import AdminNavbar from "../src/Components/AdminNavbar";
import Navbar from "../src/Components/Navbar";


export default function HomePage({user,setUser,setAddState}) {
    return (
        <div className="flex flex-row">
        <Navbar user={user} setUser={setUser}/>
        <div className="flex">
        {
          user.username == "admin" ?
          (
            <AdminNavbar setAddState={setAddState}/>
          ) : (
            <></>
          )
        }
        </div>
      </div>
    );
}