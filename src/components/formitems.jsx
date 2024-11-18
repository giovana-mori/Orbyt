/* eslint-disable */
import React from "react";

function FormItems({ fName, id, ftype }) {
  return (
    <div>
      <label htmlFor="user" className="my-1 flex">
        {fName}
      </label>
      <input
        type={ftype}
        id={id}
        name={id}
        className="flex rounded-md border bg-black"
      />
    </div>
  );
}
export default FormItems;
