using Application.Cars.Commands.CreateCar;
using Application.Cars.Commands.GuesPriceCar;
using Domain.Entities;
using FluentAssertions;

using static Application.Test.Testing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Test.Cars.Commands;

public class CreateCarTest : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateANewCar( )
    {
        var command = new CreateCarCommand(new Car("Audi", "R8", 2018, 2, "Red", 50000));

        var itemId = await SendAsync(command);

        var item = await FindAsync<Car>(itemId);

        item.Should().NotBeNull();
        item!.Price.Should().Be(command.Car.Price);
        item!.Model.Should().Be(command.Car.Model);
        item!.Make.Should().Be(command.Car.Make);
        item!.Doors.Should().Be(command.Car.Doors);
        item!.Color.Should().Be(command.Car.Color);
        item!.Year.Should().Be(command.Car.Year);  
    }
}
