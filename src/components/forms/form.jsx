import React from "react";

function Form({ children, onInput }) {
  return <form className="space-y-3" onInput={onInput}>{ children }</form>;
}
export default Form;
