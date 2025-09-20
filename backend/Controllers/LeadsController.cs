using LeadsManager.backend.data;
using LeadsManager.backend.Models;
using LeadsManager.backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeadsManager.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IEmailService _emailService;

        public LeadsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("{id}/accept")]
        public async Task<IActionResult> AcceptLead(int id)
        {
            var lead = await _appDbContext.Leads.FindAsync(id);
            if (lead == null)
            {
                return NotFound();
            }

            if (lead.Price > 500.00m)
            {
                lead.Price *= 0.9m;
            }

            lead.Status = LeadStatus.Accepted;

            _appDbContext.Leads.Update(lead);
            await _appDbContext.SaveChangesAsync();

            _emailService.SendEmailNotification();

            return Ok(lead);
        }

        [HttpPost("{id}/decline")]
        public async Task<IActionResult> DeclineLead(int id)
        {
            var lead = await _appDbContext.Leads.FindAsync(id);
            if (lead == null)
            {
                return NotFound();
            }

            lead.Status = LeadStatus.Declined;

            _appDbContext.Leads.Update(lead);
            await _appDbContext.SaveChangesAsync();

            return Ok(lead);
        }

        [HttpPost]
        public async Task<IActionResult> AddLead([FromBody] LeadCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lead = new Lead
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ContactPhone = dto.ContactPhone,
                Email = dto.Email,
                City = dto.City,
                Category = dto.Category,
                Description = dto.Description,
                Price = dto.Price,
                DateCreated = DateTime.UtcNow,
                Status = LeadStatus.Invited
            };

            await _appDbContext.Leads.AddAsync(lead);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = lead.Id }, lead);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page <= 0 || pageSize <= 0)
                return BadRequest("Page e PageSize devem ser maiores que zero.");

            var leads = await _appDbContext.Leads
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(leads);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> GetById(int id)
        {
            var lead = await _appDbContext.Leads.FindAsync(id);
            if (lead == null)
                return NotFound();

            return Ok(lead);
        }

        [HttpGet("accepted")]
        public async Task<ActionResult<IEnumerable<Lead>>> GetAcceptedLeads()
        {
            var leads = await _appDbContext.Leads
                .Where(l => l.Status == LeadStatus.Accepted)
                .ToListAsync();

            return Ok(leads);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLead(int id, [FromBody] LeadCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lead = await _appDbContext.Leads.FindAsync(id);
            if (lead == null)
                return NotFound();

            lead.FirstName = dto.FirstName;
            lead.LastName = dto.LastName;
            lead.ContactPhone = dto.ContactPhone;
            lead.Email = dto.Email;
            lead.City = dto.City;
            lead.Category = dto.Category;
            lead.Description = dto.Description;
            lead.Price = dto.Price;

            _appDbContext.Leads.Update(lead);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var lead = await _appDbContext.Leads.FindAsync(id);
            if (lead == null)
                return NotFound();

            _appDbContext.Leads.Remove(lead);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
