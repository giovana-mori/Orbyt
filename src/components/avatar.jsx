import React from 'react';

function Avatar() {
  return (
    <div className="w-[200px] flex flex-col gap-2">
      <img src="/img/avatar.jpg" alt="" className="w-full rounded-full" />
      <h2 className="text-center text-2xl text-white font-normal">Nome</h2>
      <h2 className="text-slate-400 text-xl font-normal text-center italic">@user_name</h2>
    </div>
  );
}

export default Avatar;
