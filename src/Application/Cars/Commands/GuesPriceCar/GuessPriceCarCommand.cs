using MediatR; 

namespace Application.Cars.Commands.GuesPriceCar;

public record GuessPriceCarCommand(int Id, decimal Price) : IRequest<bool>;