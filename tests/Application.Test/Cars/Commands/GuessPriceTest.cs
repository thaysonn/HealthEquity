using Application.Cars.Commands.GuesPriceCar;
using Domain.Entities;
using FluentAssertions;

using static Application.Test.Testing;

namespace Application.Test.Cars.Commands;
public class GuessPriceTest : BaseTestFixture
{ 
    [TestCase(44999)]
    [TestCase(58000)]
    [TestCase(56000)]
    [TestCase(40000)] 
    public async Task ShouldGuessPriceCarReturnFalse(decimal guessPrice)
    {
        await AddAsync(new Car("Audi", "R8", 2018, 2, "Red", 50000));
        var result = await SendAsync(new GuessPriceCarCommand(1, guessPrice));
        result.Should().BeFalse();
    }

    [TestCase(45000)]
    [TestCase(45100)]
    [TestCase(50000)]
    [TestCase(40000)]
    [TestCase(40001)]
    [TestCase(46001)]
    public async Task ShouldGuessPriceCarReturnTrue(decimal guessPrice)
    {
        await AddAsync(new Car("Audi", "R8", 2018, 2, "Red", 45000));
        var result = await SendAsync(new GuessPriceCarCommand(1, guessPrice)); 
        result.Should().BeTrue();
    }
}