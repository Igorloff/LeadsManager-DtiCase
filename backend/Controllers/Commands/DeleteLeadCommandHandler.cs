using MediatR;
using LeadsManager.backend.data;

public class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand, bool>
{
    private readonly AppDbContext _context;

    public DeleteLeadCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _context.Leads.FindAsync(request.Id);
        if (lead == null) return false;

        _context.Leads.Remove(lead);
        await _context.SaveChangesAsync();
        return true;
    }
}
