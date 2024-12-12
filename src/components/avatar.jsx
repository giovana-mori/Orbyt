import React from 'react';

function Avatar({ nome }) {
  return (
    <div className="w-[200px] flex flex-col gap-2">
      <img src="/img/avatar.jpg" alt="" className="w-full rounded-full" />
      <h2 className="text-center text-2xl text-white font-normal">{nome}</h2>
      <h2 className="text-slate-400 text-xl font-normal text-center italic">{`@${nome}`}</h2>
    </div>
  );
}

export default Avatar;
