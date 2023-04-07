export default function Unauthorized() {
    return(
        <div className="flex w-screen h-screen">
            <div className="flex m-auto flex-col">
                <h1 className="m-auto my-4 text-6xl">{"Sorry :("}</h1>
                <h1 className="m-auto my-4">You don't have access to this page</h1>
            </div>
        </div>
    );
}