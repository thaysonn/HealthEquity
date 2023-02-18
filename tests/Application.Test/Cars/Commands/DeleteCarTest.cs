using Application.Cars.Commands.DeleteCar;
using Domain.Entities;
using FluentAssertions;

using static Application.Test.Testing;

namespace Application.Test.Cars.Commands;

public class DeleteCarTest : BaseTestFixture
{
    [Test]
    public async Task ShouldDeleteACar()
    {
        var car = new Car("Audi", "R8", 2018, 2, "Red", 50000);
        await AddAsync(car);
         
        var itemAdd = await FindAsync<Car>(car.Id);
        itemAdd.Should().NotBeNull();

        var command = new DeleteCarCommand(car.Id);

        await SendAsync(command);

        var itemDelete = await FindAsync<Car>(car.Id);
        itemDelete.Should().BeNull();
    } 
}
