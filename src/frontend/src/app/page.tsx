'use client'

import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import { getPokemon } from '@/core/server/config';

interface PokemonItem {
  name: string;
  url: string;
}

const HomePage = () => {
  const [pokemonList, setPokemonList] = useState<PokemonItem[]>([]);

  useEffect(() => {
    const apiUrl = getPokemon();
    console.log('API URL:', apiUrl);

    fetch(apiUrl)
      .then(response => {
        console.log('Response status:', response.status);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => {
        console.log('API response:', data);
        if (Array.isArray(data)) {
          setPokemonList(data);
        } else {
          console.error('Invalid data structure:', data);
          throw new Error('Invalid data structure');
        }
      })
      .catch(error => {
        console.error('Error fetching Pokémon list:', error);
        setPokemonList([]);
      });
  }, []);

  return (
    <div className="container mx-auto px-4">
      <h1 className="text-2xl font-bold mb-4">Pokémon List</h1>
      <ul>
        {pokemonList.length > 0 ? (
          pokemonList.map((item, index) => (
            <li key={index} className="mb-2">
              <Link href={`/pokemon/${item.name}`}>
                {item.name}
              </Link>
            </li>
          ))
        ) : (
          <li>No Pokémon found</li>
        )}
      </ul>
    </div>
  );
};

export default HomePage;