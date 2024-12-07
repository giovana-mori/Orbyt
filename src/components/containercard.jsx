import React from "react";

function ContainerCard({ children }) {
  return (
    <div className="container mx-auto">
      <div className="bg-black rounded-xl border border-white mx-auto bg-opacity-65 mt-5 p-5">
        {children}
      </div>
    </div>
  );
}

export default ContainerCard;
