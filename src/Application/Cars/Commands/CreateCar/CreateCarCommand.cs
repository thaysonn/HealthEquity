using Domain.Entities;
using MediatR;

namespace Application.Cars.Commands.CreateCar;

public record CreateCarCommand(Car Car) : IRequest<int>;