using MediatR;

namespace Application.Cars.Commands.DeleteCar;

public record DeleteCarCommand(int Id) : IRequest;