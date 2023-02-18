using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cars.Commands.GuesPriceCar;
public class GuessPriceCarCommandHandler : IRequestHandler<GuessPriceCarCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public GuessPriceCarCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<bool> Handle(GuessPriceCarCommand request, CancellationToken cancellationToken)
    { 
        var entity = await _context.Cars.FirstOrDefaultAsync(el => el.Id == request.Id);

        if (entity == null) throw new ArgumentException("Id invalid.");

        decimal max = entity.Price + 5000;
        decimal min = entity.Price - 5000;

        if (request.Price >= min && request.Price <= max) return true;

        return false;
    }
}