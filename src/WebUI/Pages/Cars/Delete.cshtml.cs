using Application.Cars.Commands.DeleteCar;
using Application.Cars.Queries.GetCars;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Pages.Cars;
public class DeleteModel : Common.PageBase
{
    [BindProperty]
    public Car Car { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is not null)
            this.Car = await Mediator.Send(new GetCarByIdQuery() { Id = id.Value });
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null) return NotFound();

        await Mediator.Send(new DeleteCarCommand(id.Value));
        return RedirectToPage("./Index");
    }
}
