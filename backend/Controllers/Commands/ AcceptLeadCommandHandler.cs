using MediatR;
using LeadsManager.backend.data;
using LeadsManager.backend.Models;

public class AcceptLeadCommandHandler : IRequestHandler<AcceptLeadCommand, Lead>
{
    private readonly AppDbContext _context;
    private readonly IEmailService _emailService;

    public AcceptLeadCommandHandler(AppDbContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task<Lead> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _context.Leads.FindAsync(request.Id);
        if (lead == null) return null;

        if (lead.Price > 500m) lead.Price *= 0.9m;
        lead.Status = LeadStatus.Accepted;

        await _context.SaveChangesAsync();

        try { _emailService.SendEmailNotification(); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        return lead;
    }
}
