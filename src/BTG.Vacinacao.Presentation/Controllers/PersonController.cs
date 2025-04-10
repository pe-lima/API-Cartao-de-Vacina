﻿using BTG.Vacinacao.Application.Commands.PersonCommand;
using BTG.Vacinacao.Application.DTOs;
using BTG.Vacinacao.Application.Queries.VaccinationCardQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BTG.Vacinacao.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Register([FromBody] RegisterPersonCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Register), new { id = result.Id }, result);
        }

        [HttpGet("{cpf}/vaccination-card")]
        public async Task<ActionResult<VaccinationCardDto>> GetVaccinationCardByCpf(string cpf)
        {
            var query = new GetVaccinationCardByCpfQuery(cpf);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
