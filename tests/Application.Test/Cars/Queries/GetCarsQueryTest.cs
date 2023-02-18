using Application.Cars.Queries.GetCars;
using Domain.Entities;
using FluentAssertions;

namespace Application.Test.Cars.Queries;

using static Testing;
public class GetCarsQueryTest : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnAllCars()
    {
        await AddAsync(new Car("Audi", "R8", 2018, 2, "Red", 79995));

        var result = await SendAsync(new GetCarsQuery());

        result.Should().HaveCount(1);
        result.First().Model.Should().Be("R8");
        result.First().Make.Should().Be("Audi");
        result.First().Color.Should().Be("Red");
        result.First().Year.Should().Be(2018);
        result.First().Price.Should().Be(79995); 
    }

    [Test]
    public async Task ShouldReturnACar()
    {
        await AddAsync(new Car("Audi", "R8", 2018, 2, "Red", 79995));

        var result = await SendAsync(new GetCarByIdQuery() { Id = 1 });

        result.Model.Should().Be("R8");
        result.Make.Should().Be("Audi");
        result.Color.Should().Be("Red");
        result.Year.Should().Be(2018);
        result.Price.Should().Be(79995);
    }
}
