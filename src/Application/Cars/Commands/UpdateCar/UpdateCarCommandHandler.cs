using Application.Cars.Commands.CreateCar;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cars.Commands.UpdateCar;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCarCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        if (request?.Car == null)
            throw new ArgumentException("Car invalid.");

        var entity = await _context.Cars.FirstOrDefaultAsync(el => el.Id == request.Car.Id);

        if (entity == null)
            throw new ArgumentException("Id invalid.");

        entity.Make = request.Car.Make;
        entity.Model = request.Car.Model;
        entity.Year = request.Car.Year;
        entity.Doors = request.Car.Doors;
        entity.Price = request.Car.Price;
        entity.Color = request.Car.Color;

        _context.Cars.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

