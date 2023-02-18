using Domain.Entities;
using MediatR;

namespace Application.Cars.Commands.UpdateCar;

public record UpdateCarCommand(Car Car) : IRequest;