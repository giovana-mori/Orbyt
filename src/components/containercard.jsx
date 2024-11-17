import React from "react";

function ContainerCard({ children }) {
  return (
    <div className="bg-black rounded-md border border-white max-w-[1400px]">{children}</div>
  );
}

export default ContainerCard;
