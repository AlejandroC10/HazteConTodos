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
        var pkAttacker = Substitute.For<IPokemonAttacker>();

        // Act
        pkAttacker.CalculateDamage(10).Returns(5);
        var attack = pkAttacker.CalculateDamage(10);
        
        // Assert
        attack.Should().Be(5);
        attack.Should().BeLessThan(10);
        attack.Should().BeGreaterOrEqualTo(1);
    }
}