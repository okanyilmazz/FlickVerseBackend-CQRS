﻿using Application.Features.Languages.Commands.Create;
using Application.Features.Languages.Commands.Delete;
using Application.Features.Languages.Commands.Update;
using Application.Features.Languages.Queries.GetById;
using Application.Features.Languages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
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

    [HttpPut]
    public async Task<ActionResult<UpdatedLanguageResponse>> Update([FromBody] UpdateLanguageCommand command)
    {
        UpdatedLanguageResponse response = await mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLanguageResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdLanguageQuery query = new() { Id = id };

        GetByIdLanguageResponse response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLanguageListItemDto>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLanguageQuery query = new() { PageRequest = pageRequest };
        GetListResponse<GetListLanguageListItemDto> response = await mediator.Send(query);

        return Ok(response);
    }


}