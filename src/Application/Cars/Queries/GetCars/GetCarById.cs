using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cars.Queries.GetCars;

public record GetCarByIdQuery : IRequest<Car>
{
    public int Id { get; set; }
}

public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, Car>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCarByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken) =>
        await _context.Cars.FirstOrDefaultAsync(el => el.Id == request.Id);
}