using LeadsManager.backend.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeadsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddLead([FromBody] LeadCreateDto dto)
    {
        var lead = await _mediator.Send(new AddLeadCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id = lead.Id }, lead);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLead(int id, [FromBody] LeadCreateDto dto)
    {
        var success = await _mediator.Send(new UpdateLeadCommand(id, dto));
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var success = await _mediator.Send(new DeleteLeadCommand(id));
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpPost("{id}/accept")]
    public async Task<IActionResult> AcceptLead(int id)
    {
        var lead = await _mediator.Send(new AcceptLeadCommand(id));
        if (lead == null) return NotFound();
        return Ok(lead);
    }

    [HttpPost("{id}/decline")]
    public async Task<IActionResult> DeclineLead(int id)
    {
        var lead = await _mediator.Send(new DeclineLeadCommand(id));
        if (lead == null) return NotFound();
        return Ok(lead);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var lead = await _mediator.Send(new GetLeadByIdQuery(id));
        if (lead == null) return NotFound();
        return Ok(lead);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var leads = await _mediator.Send(new GetAllLeadsQuery(page, pageSize));
        return Ok(leads);
    }

    [HttpGet("status/accepted")]
    public async Task<IActionResult> GetAcceptedLeads()
    {
        var leads = await _mediator.Send(new GetAcceptedLeadsQuery());
        return Ok(leads);
    }

    [HttpGet("status/invited")]
    public async Task<IActionResult> GetInvitedLeads()
    {
        var leads = await _mediator.Send(new GetInvitedLeadsQuery());
        return Ok(leads);
    }
}
