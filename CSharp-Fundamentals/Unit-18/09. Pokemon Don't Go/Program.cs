using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int indexRemovePokemon = -1;
            bool pokemonIndexBelowZero = false, pokemonIndexOverLastIndex = false;
            int sumOfRemovedPokemons = 0;

            while (pokemons.Count > 0)
            {
                indexRemovePokemon = int.Parse(Console.ReadLine());
                pokemonIndexBelowZero = false;
                pokemonIndexOverLastIndex = false ;

                if (indexRemovePokemon < 0)
                {
                    indexRemovePokemon = 0;
                    pokemonIndexBelowZero = true ;  
                }
                if (indexRemovePokemon > pokemons.Count-1)
                {
                    indexRemovePokemon = pokemons.Count-1;
                    pokemonIndexOverLastIndex = true ;
                }

                int valueRemovedPokemon = pokemons[indexRemovePokemon];
                sumOfRemovedPokemons += valueRemovedPokemon;
                pokemons.RemoveAt(indexRemovePokemon);
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= valueRemovedPokemon)
                    {
                        pokemons[i] += valueRemovedPokemon;
                    }
                    else if (pokemons[i] > valueRemovedPokemon)
                    {
                        pokemons[i] -= valueRemovedPokemon;
                    }
                }
                if (pokemonIndexBelowZero)
                {
                    pokemons.Insert(0, pokemons[pokemons.Count-1]);
                }
                if (pokemonIndexOverLastIndex)
                {
                    pokemons.Add(pokemons[0]);
                }
            }
            Console.WriteLine(sumOfRemovedPokemons);
        }
    }
}
