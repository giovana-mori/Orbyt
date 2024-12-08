import React from "react";
import { Link } from "react-router-dom";

export default function CommentForm({ enableComment = false }) {
  if (!enableComment) {
    return (
      <div className="bg-[#181818] rounded-md flex flex-col items-center justify-center gap-3 my-2 p-3 min-h-28">
        <Link
          to="/login"
          className="text-white font-bold text-lgbg-white rounded-lg px-2 flex flex-col items-center justify-center"
        >
          Faça login para comentar
        </Link>
      </div>
    );
  }

  return (
    <div className="bg-[#181818] rounded-md flex flex-col gap-3 my-2 p-3">
      <div className="flex flex-row w-full items-center justify-center">
        <img className="w-8" src="/img/star.svg" alt="" />
        <img className="w-8" src="/img/star.svg" alt="" />
        <img className="w-8" src="/img/star.svg" alt="" />
        <img className="w-8" src="/img/star.svg" alt="" />
        <img className="w-8" src="/img/star.svg" alt="" />
      </div>
      <textarea
        name=""
        id=""
        className="w-full resize-none rounded-md bg-zinc-500 text-white min-h-40 text-xl p-3 font-bold"
        placeholder="Escreva um comentário sobre"
      />
      <label htmlFor="?" className="text-white flex items-center gap-2">
        <input
          type="checkbox"
          name="spoiler"
          id="spoiler"
          className="size-5 bg-transparent"
        />
        Marcar comentário como spoiler
      </label>
    </div>
  );
}
