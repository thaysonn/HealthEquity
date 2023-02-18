using Application.Cars.Queries.GetCars;
using Domain.Entities; 

namespace WebUI.Pages.Cars;
 
public class IndexModel : Common.PageBase
{
    public IEnumerable<Car> Cars { get; set; } = new List<Car>();
     
    public async Task OnGet()  =>
        this.Cars = await Mediator.Send(new GetCarsQuery()); 
}
