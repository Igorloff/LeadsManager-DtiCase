using MediatR;
using LeadsManager.backend.data;
using Microsoft.EntityFrameworkCore;

public class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateLeadCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _context.Leads.FindAsync(request.Id);
        if (lead == null) return false;

        var dto = request.LeadDto;
        lead.FirstName = dto.FirstName;
        lead.LastName = dto.LastName;
        lead.ContactPhone = dto.ContactPhone;
        lead.Email = dto.Email;
        lead.City = dto.City;
        lead.Category = dto.Category;
        lead.Description = dto.Description;
        lead.Price = dto.Price;

        _context.Leads.Update(lead);
        await _context.SaveChangesAsync();
        return true;
    }
}
