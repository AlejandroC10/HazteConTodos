﻿using Domain;

namespace Json.Interfaces;

public interface IPokemonDb
{
    public List<Pokemon> ReadPokemon();
}