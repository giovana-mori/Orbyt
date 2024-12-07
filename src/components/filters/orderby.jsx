import React from "react";
import SingleSelect from "./dropdowns/singleselect";

function OrderBy() {
  const orderby = [
    { id: 1, label: "Mais recentes" },
    { id: 2, label: "Mais antigos" },
    { id: 3, label: "A-Z" },
    { id: 4, label: "Z-A" },
    { id: 5, label: "Maior nota" },
    { id: 6, label: "Menor nota" },
    { id: 7, label: "Nº de avaliações" },
  ];

  const handleChange = (selected) => {
    console.log('Ordenar por:', selected);
  };

  return (
    <div className="p-4">
      <SingleSelect elements={orderby} title="Ordenar" onChange={handleChange} />
    </div>
  );
}

export default OrderBy;
