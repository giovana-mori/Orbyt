/*eslint-disable*/
import React from "react";

function InputLabel({
  id,
  label,
  placeholder,
  type,
  name,
}) {
  return (
    <div className="mb-4">
      <label
        htmlFor={id}
        className="block mb-2 text-sm font-medium text-white"
      >
        {label}
        <input
          name={name}
          type={type}
          id={id}
          className="shadow-sm bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 dark:shadow-sm-light mt-2"
          placeholder={placeholder}
          required
        />
      </label>
    </div>
  );
}
export default InputLabel;
