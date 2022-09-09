using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Domain;
using FluentAssertions;
using Infrastructure;
using NSubstitute;
using Xunit;

namespace Application.Tests;

public class PokemonAttackerShould
{
    [Fact]
    public void GiveAttacker()
    {
        // Arrange
        var pkAttacker = new PokemonAttacker();

        // Act
        var attack = pkAttacker.CalculateDamage(10);
        
        // Assert
        attack.Should().BeLessThan(10);
        attack.Should().BeGreaterOrEqualTo(1);
    }
}