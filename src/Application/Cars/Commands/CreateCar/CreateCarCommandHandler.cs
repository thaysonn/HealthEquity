using Application.Common.Interfaces;
using MediatR;

namespace Application.Cars.Commands.CreateCar;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCarCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        await _context.Cars.AddAsync(request.Car);
        await _context.SaveChangesAsync(cancellationToken);
        return request.Car.Id;
    }
}
