import React from 'react';

function ItemComentario() {
  return (
    <div className="bg-[#181818] border border-[#858585] rounded-2xl px-4 py-3 max-w-[450px] w-full flex flex-col gap-3 ">
      <div className="flex flex-row gap-4">
        <div className="w-16 h-16 bg-[#858585] rounded-full overflow-hidden">
          <img src="/img/avatar.jpg" alt="" />
        </div>
        <div className="flex flex-col items-center">
          <h1 className="text-white font-semibold text-lg">Nome do usuário</h1>
          <div className="flex flex-row w-full">
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
            <img className="w-8" src="/img/star.svg" alt="" />
          </div>
        </div>
      </div>
      <div className="flex flex-col gap-4">
        <p className="text-white font-normal text-sm line-clamp-4 text-justify">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas
          facilisis elementum porttitor. Maecenas et mi ac elit vestibulum
          posuere eu sit amet eros. Suspendisse aliquam varius congue.
        </p>
      </div>
      <div className="flex flex-row gap-4">
        <div className="flex flex-row gap-2">
          <img src="/img/like.svg" alt="" />
          <span className="text-white font-normal text-lg">10</span>
        </div>
        <div className="flex flex-row gap-2">
          <img src="/img/deslike.svg" alt="" />
          <span className="text-white font-normal text-lg">10</span>
        </div>
      </div>
    </div>
  );
}
export default ItemComentario;
