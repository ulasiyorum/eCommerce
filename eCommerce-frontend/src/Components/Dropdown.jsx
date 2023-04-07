import { Fragment, useState } from 'react'
import { Listbox } from '@headlessui/react'
import { ChevronDownIcon } from '@heroicons/react/20/solid'
export default function Dropdown({options}) {
    const [selected, setSelected] = useState({item:options[0],label:'Select an option'});
    const [open, setOpen] = useState(false);

    return (
        <Listbox value={open} onChange={() => setOpen(!open)}>
          <Listbox.Button className="relative w-inherit py-2 pl-3 pr-10 text-left bg-white rounded-md shadow-sm cursor-pointer focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 sm:text-sm">
            <span className="block truncate">{selected.label}</span>
            <span className="absolute inset-y-0 right-0 flex items-center pr-2 pointer-events-none">
              <ChevronDownIcon className="w-5 h-5 text-gray-400" aria-hidden="true" />
            </span>
          </Listbox.Button>
          <Listbox.Options className="absolute w-fit py-1 mt-1 overflow-auto text-base bg-white rounded-md shadow-lg max-h-60 ring-1 ring-black ring-opacity-5 focus:outline-none sm:text-sm">
            {options.map((option,index) => (
              <Listbox.Option key={option + index} onClick={() => setSelected({item:option,label:option})} value={option}>
                {({ active, selected }) => (
                  <div
                    className={`${
                      active ? 'text-black  bg-blue-600' : 'text-gray-900'
                    } cursor-default select-none relative py-2 pl-3 pr-9`}
                  >
                    <span className={`${selected ? 'font-medium' : 'font-normal'} block truncate`}>
                      {option}
                    </span>
                    {selected && (
                      <span
                        className={`${active ? 'text-white' : 'text-blue-600'}
                              absolute inset-y-0 right-0 flex items-center pr-4`}
                      >
                        <CheckIcon className="w-5 h-5" aria-hidden="true" />
                      </span>
                    )}
                  </div>
                )}
              </Listbox.Option>
            ))}
          </Listbox.Options>
        </Listbox>
      );
  }