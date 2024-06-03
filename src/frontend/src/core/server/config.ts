// TODO: move to env variables if private data ... process.env.NEXT_PUBLIC_API_URL...

export const BASE_URL = "http://localhost:5000";
export const API_URL = "/api/pokemon";

export const getPokemon = () => `${BASE_URL}${API_URL}`;
export const getPokemonById = (id: number) => `${BASE_URL}${API_URL}/${id}`;
export const getPokedex = () => `${BASE_URL}${API_URL}/pokedex`;
export const postPokedex = (id: number) =>
  `${BASE_URL}${API_URL}/${id}/pokedex`;
export const deletePokedex = (id: number) =>
  `${BASE_URL}${API_URL}/${id}/pokedex`;
