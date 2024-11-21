/*eslint-disable*/
import React, { useState } from 'react';

const SingleSelect = ({ elements, title, onChange = () => {} }) => {
  const [isOpen, setIsOpen] = useState(false);
  const [selectedElement, setSelectedElement] = useState(null);

  const selectElement = (element) => {
    setSelectedElement(element);
    onChange(element);
    setIsOpen(false);
  };

  const toggleDropdown = () => setIsOpen(!isOpen);

  return (
    <div className='flex items-center'>
      <div className="relative w-44 max-w-xs">
        <button
          type="button"
          onClick={toggleDropdown}
          className="border border-white bg-black p-1 rounded-full w-full text-center text-white flex flex-row items-center justify-center max-w-44 mx-auto gap-2"
        >
          <div className="flex flex-wrap gap-1">
            {selectedElement ? (
              <span className="inline-flex items-center px-2 py-0.5 rounded-full bg-white text-black font-roboto font-semibold text-sm">
                {selectedElement.label}
              </span>
            ) : (
              <span className="text-white font-bebas text-2xl">{title}</span>
            )}
          </div>
        </button>

        {isOpen && (
          <div className="absolute z-10 w-full bg-black text-white font-roboto font-semibold border rounded-md shadow-lg max-h-60 overflow-auto">
            {elements.map((element) => (
              <div
                key={element.id}
                className="flex items-center px-4 py-2 hover:bg-white hover:text-black cursor-pointer"
                onClick={() => selectElement(element)}
              >
                <span className="ml-2">{element.label}</span>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
};

export default SingleSelect;
