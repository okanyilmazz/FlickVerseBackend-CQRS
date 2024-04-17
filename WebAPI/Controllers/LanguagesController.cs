using Application.Features.Languages.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{

    private readonly IMediator mediator;

    public LanguagesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreatedLanguageResponse>> Add([FromBody] CreateLanguageCommand command)
    {
        CreatedLanguageResponse response = await mediator.Send(command);

        return Ok(response);
    }

}
