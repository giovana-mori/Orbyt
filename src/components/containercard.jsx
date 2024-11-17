import React from "react";

function ContainerCard({ children }) {
  return (
    <div className="bg-black rounded-xl border border-white max-w-[1400px] mx-auto bg-opacity-65 mt-5 p-5">{children}</div>
  );
}

export default ContainerCard;
