using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Common;

public class PageBase : PageModel
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}

