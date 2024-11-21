/*eslint-disable*/
import React, { useState } from 'react';

const MultiSelect = ({ elements, title, onChange = () => {} }) => {
  const [isOpen, setIsOpen] = useState(false);
  const [selectedElements, setSelectedElements] = useState([]);
  
  const toggleElement = (element) => {
    const updatedSelection = selectedElements.includes(element)
      ? selectedElements.filter(item => item.id !== element.id)
      : [...selectedElements, element];
    
      setSelectedElements(updatedSelection);
    onChange(updatedSelection);
  };

  const toggleDropdown = () => setIsOpen(!isOpen);

  const removeElement = (elementToRemove) => {
    const updatedSelection = selectedElements.filter(
      item => item.id !== elementToRemove.id
    );
    setSelectedElements(updatedSelection);
    onChange(updatedSelection);
  };

  return (
    <div className='flex items-center'>
      <div className="relative w-44 max-w-xs">
        <button
          type="button"
          onClick={toggleDropdown}
          className="border border-white bg-black p-1 rounded-full w-full text-center text-white flex flex-row items-center justify-center max-w-44 mx-auto gap-2"
        >
          <div className="flex flex-wrap gap-1">
            {selectedElements.length === 0 ? (
              <span className="text-white font-bebas text-2xl">{title}</span>
            ) : (
              selectedElements.map((element) => (
                <span
                  key={element.id}
                  className="inline-flex items-center px-2 py-0.5 min-h-8 rounded-full bg-white text-black font-roboto font-semibold text-sm"
                >
                  {element.label}
                  <button
                    type="button"
                    onClick={(e) => {
                      e.stopPropagation();
                      removeElement(element);
                    }}
                    className="ml-1 hover:text-blue-900"
                  >
                  </button>
                </span>
              ))
            )}
          </div>
        </button>

        {isOpen && (
          <div className="absolute z-10 w-full bg-black text-white font-roboto font-semibold border rounded-md shadow-lg max-h-60 overflow-auto">
            {elements.map((element) => (
              <div
                key={element.id}
                className="flex items-center px-4 py-2 hover:bg-white hover:text-black cursor-pointer"
                onClick={() => toggleElement(element)}
              >
                <input
                  type="checkbox"
                  checked={selectedElements.some(item => item.id === element.id)}
                  onChange={() => {}}
                  className="h-4 w-4 text-blue-600 rounded border-white input:bg-black input:border-white"
                />
                <span className="ml-2">{element.label}</span>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
};


export default MultiSelect;