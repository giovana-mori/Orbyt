/* eslint-disable */
import React from "react";
import PrevFilme from "./prevfilme";

export default function BannerHome(
    {
        imgpath = "img/openheimmer.jpg",
        title = "Openheimmer",
        description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        nota = 5,
        genero = ["Suspense", "Terror", "Comédia"]

    }
) {
    return (
        <div className="h-screen bg-cover bg-center bg-no-repeat py-20" style={{ backgroundImage: `url(${imgpath})` }}>
            <div className="container mx-auto">
                <div>
                    <PrevFilme titulo={title} genero={genero} descricao={description} nota={nota} />
                </div>
                <div>
                </div>
            </div>
        </div>
    );
}
