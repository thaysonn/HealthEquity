using Application.Cars.Commands.GuesPriceCar;
using Application.Cars.Queries.GetCars;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Pages.Cars;
public class GuessPriceModel : Common.PageBase
{ 
    public Car Car { get; set; }
    [BindProperty]
    public bool Result { get; set; }

    [Required(ErrorMessage = "The Guess Price field is required.\r\n")]
    [BindProperty]    
    public decimal? GuessPrice { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
            return NotFound();

        this.Car = await Mediator.Send(new GetCarByIdQuery() { Id = id.Value });
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        this.Car = await Mediator.Send(new GetCarByIdQuery() { Id = id });
        if (!ModelState.IsValid) { return Page(); }

        this.Result = await Mediator.Send(new GuessPriceCarCommand(id, this.GuessPrice.Value));

        return Page();
    }
}
