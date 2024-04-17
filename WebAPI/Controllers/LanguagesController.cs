using Application.Features.Languages.Commands.Create;
using Application.Features.Languages.Commands.Delete;
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

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLanguageResponse>> Delete([FromRoute] Guid id)
    {
        DeleteLanguageCommand command = new() { Id = id };

        DeletedLanguageResponse response = await mediator.Send(command);

        return Ok(response);
    }

}
