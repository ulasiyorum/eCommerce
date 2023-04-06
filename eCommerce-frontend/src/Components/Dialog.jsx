import { useState } from 'react';

function Modal({className}) {

    const [isOpen, setIsOpen] = useState(false); 
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

  const handleOpen = () => {
    setIsOpen(true);
  };

  const handleClose = () => {
    setIsOpen(false);
  };

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };

  const handleFormSubmit = (e) => {
    e.preventDefault();

    // perform login logic here
  };

  return (
    <>
      {/* Button to open the modal */}
      <button className={className} onClick={handleOpen}>Login</button>

      {/* Modal */}
      {isOpen && (
        <div className="absolute w-screen h-screen z-10 inset-0 overflow-y-auto">
          <div className="flex items-center justify-center min-h-screen">
            <div
              className="absolute w-screen h-screen inset-0 bg-black opacity-50"
              onClick={handleClose}
            ></div>
            <div className="relative bg-white rounded-lg max-w-md mx-auto p-8">
              <button
                className="absolute top-0 right-0 p-2 text-gray-500 hover:text-gray-600"
                onClick={handleClose}
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  className="h-6 w-6"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M6 18L18 6M6 6l12 12"
                  />
                </svg>
              </button>
              <h2 className="text-lg font-medium mb-4">Login</h2>
              <form onSubmit={handleFormSubmit}>
                <div className="mb-4">
                  <label
                    htmlFor="email"
                    className="block text-gray-700 font-medium mb-2"
                  >
                    Email
                  </label>
                  <input
                    type="email"
                    id="email"
                    name="email"
                    className="w-full rounded-md border-solid border-2 border-black  focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 px-4 py-2"
                    value={email}
                    onChange={handleEmailChange}
                  />
                </div>
                <div className="mb-4">
                  <label
                    htmlFor="password"
                    className="block text-gray-700 font-medium mb-2"
                  >
                    Password
                  </label>
                  <input
                    type="password"
                    id="password"
                    name="password"
                    className="w-full rounded-md border-solid border-2 border-black  focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 px-4 py-2"
                    value={password}
                    onChange={handlePasswordChange}
                  />
                </div>
                <button
                  type="submit"
                  className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2"
                >
                  Login
                </button>
              </form>
            </div>
          </div>
        </div>
      )}
    </>
  );
}

export default Modal;

export function RegisterModal({className}) {
        const [isOpen, setIsOpen] = useState(false);
        const [email, setEmail] = useState('');
        const [password, setPassword] = useState('');
      
        const handleOpen = () => {
          setIsOpen(true);
        };
      
        const handleClose = () => {
          setIsOpen(false);
        };
      
        const handleEmailChange = (e) => {
          setEmail(e.target.value);
        };
      
        const handlePasswordChange = (e) => {
          setPassword(e.target.value);
        };
      
        const handleFormSubmit = (e) => {
          e.preventDefault();
      
          // perform login logic here
        };
      
        return (
          <>
            {/* Button to open the modal */}
            <button className={className} onClick={handleOpen}>Register</button>
      
            {/* Modal */}
            {isOpen && (
              <div className="absolute w-screen h-screen z-10 inset-0 overflow-y-auto">
                <div className="flex items-center justify-center min-h-screen">
                  <div
                    className="absolute w-screen h-screen inset-0 bg-black opacity-50"
                    onClick={handleClose}
                  ></div>
                  <div className="relative bg-white rounded-lg max-w-md mx-auto p-8">
                    <button
                      className="absolute top-0 right-0 p-2 text-gray-500 hover:text-gray-600"
                      onClick={handleClose}
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        className="h-6 w-6"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                      >
                        <path
                          strokeLinecap="round"
                          strokeLinejoin="round"
                          strokeWidth={2}
                          d="M6 18L18 6M6 6l12 12"
                        />
                      </svg>
                    </button>
                    <h2 className="text-lg font-medium mb-4">Register</h2>
                    <form onSubmit={handleFormSubmit}>
                      <div className="mb-4">
                        <label
                          htmlFor="email"
                          className="block text-gray-700 font-medium mb-2"
                        >
                          Email
                        </label>
                        <input
                          type="email"
                          id="email"
                          name="email"
                          className="w-full rounded-md border-solid border-2 border-black focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 px-4 py-2"
                          value={email}
                          onChange={handleEmailChange}
                        />
                      </div>
                      <div className="mb-4">
                        <label
                          htmlFor="password"
                          className="block text-gray-700 font-medium mb-2"
                        >
                          Password
                        </label>
                        <input
                          type="password"
                          id="password"
                          name="password"
                          className="w-full rounded-md border-solid border-2 border-black focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 px-4 py-2"
                          value={password}
                          onChange={handlePasswordChange}
                        />
                      </div>
                      <button
                        type="submit"
                        className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2"
                      >
                        Register
                      </button>
                    </form>
                  </div>
                </div>
              </div>
            )}
          </>
        );
}





