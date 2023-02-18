using Application.Cars.Commands.CreateCar;
using Application.Cars.Commands.UpdateCar;
using Application.Cars.Queries.GetCars;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Pages.Cars;
public class CreateOrEditModel : Common.PageBase
{
    [BindProperty]
    public Car Car { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    { 
        if (id > 0) this.Car = await Mediator.Send(new GetCarByIdQuery() { Id = id });

        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (this.Car.Id == 0)
        {
            await Mediator.Send(new CreateCarCommand(this.Car));
        }
        else
        {
            await Mediator.Send(new UpdateCarCommand(this.Car));
        }

        return RedirectToPage("./Index");
    }
}
