using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    { 
        if (!_context.Cars.Any())
        {
            _context.Cars.Add(new("Audi", "R8", 2018, 2, "Red", 79995));
            _context.Cars.Add(new("Tesla", "3", 2018, 4, "Black", 54995));
            _context.Cars.Add(new("Porsche", "911 991", 2020, 2, "White", 155000));
            _context.Cars.Add(new("Mercedes-Benz", "GLE 63S", 2021, 5, "Blue", 83995));
            _context.Cars.Add(new("BMW", "X6 M", 2020, 5, "Silver", 62995));

            await _context.SaveChangesAsync();
        }
    }
}
