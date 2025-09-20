using MediatR;
using LeadsManager.backend.data;
using LeadsManager.backend.Models;

public class AddLeadCommandHandler : IRequestHandler<AddLeadCommand, Lead>
{
    private readonly AppDbContext _context;

    public AddLeadCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Lead> Handle(AddLeadCommand request, CancellationToken cancellationToken)
    {
        var dto = request.LeadDto;
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

        await _context.Leads.AddAsync(lead);
        await _context.SaveChangesAsync();
        return lead;
    }
}
