using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cars.Queries.GetCars;

public record GetCarsQuery : IRequest<IEnumerable<Car>>;

public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, IEnumerable<Car>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCarsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Car>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cars
                .AsNoTracking() 
                .ToListAsync();
    }
}