using MediatR;
using LeadsManager.backend.data;
using LeadsManager.backend.Models;

public class DeclineLeadCommandHandler : IRequestHandler<DeclineLeadCommand, Lead>
{
    private readonly AppDbContext _context;

    public DeclineLeadCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Lead> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _context.Leads.FindAsync(request.Id);
        if (lead == null) return null;

        lead.Status = LeadStatus.Declined;
        _context.Leads.Update(lead);
        await _context.SaveChangesAsync();
        return lead;
    }
}
