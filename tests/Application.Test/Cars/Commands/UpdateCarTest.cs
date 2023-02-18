using Application.Cars.Commands.UpdateCar;
using Domain.Entities;
using FluentAssertions;

using static Application.Test.Testing;

namespace Application.Test.Cars.Commands;

public class UpdateCarTest : BaseTestFixture
{
    [Test]
    public async Task ShouldUpdateCar()
    {
        var newCar = new Car("Audi", "R8", 2018, 2, "Red", 79995);
        await AddAsync(newCar);

        var item = await FindAsync<Car>(newCar.Id); 
        item.Should().NotBeNull();
         

        var commandUpdate = new UpdateCarCommand(new Car("Audi 2", "R9", 2022, 4, "White", 55000) { Id = newCar.Id });
        await SendAsync(commandUpdate);

        var carUpdated = await FindAsync<Car>(newCar.Id);

        carUpdated.Should().NotBeNull();
        carUpdated!.Price.Should().Be(commandUpdate.Car.Price);
        carUpdated!.Model.Should().Be(commandUpdate.Car.Model);
        carUpdated!.Make.Should().Be(commandUpdate.Car.Make);
        carUpdated!.Doors.Should().Be(commandUpdate.Car.Doors);
        carUpdated!.Color.Should().Be(commandUpdate.Car.Color);
        carUpdated!.Year.Should().Be(commandUpdate.Car.Year);
    }
}
