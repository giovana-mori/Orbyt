import React from 'react';
import MultiSelect from './dropdowns/multiselect';

function Category() {
  const categories = [
    { id: 1, value: "category2", label: "Ação" },
    { id: 2, value: "category3", label: "Animação" },
    { id: 3, value: "category4", label: "Aventura" },
    { id: 4, value: "category5", label: "Comédia" },
    { id: 5, value: "category6", label: "Documentário" },
    { id: 6, value: "category7", label: "Drama" },
    { id: 7, value: "category8", label: "Fantasia" },
    { id: 8, value: "category9", label: "Ficção científica" },
    { id: 9, value: "category10", label: "Musical" },
    { id: 10, value: "category11", label: "Romance" },
    { id: 11, value: "category12", label: "Suspense" },
    { id: 12, value: "category13", label: "Terror" },
    { id: 13, value: "category14", label: "Western" },
  ];

  const handleChange = (selected) => {
    console.log('Categorias selecionadas:', selected);
  };

  return (
    <div className="p-4">
      <MultiSelect elements={categories} title="Categorias" onChange={handleChange} />
    </div>
  );
}

export default Category;
