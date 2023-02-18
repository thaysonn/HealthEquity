using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cars.Commands.DeleteCar;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCarCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cars.FirstOrDefaultAsync(el => el.Id == request.Id);

        if (entity == null)
            throw new ArgumentException("Id invalid.");

        _context.Cars.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

