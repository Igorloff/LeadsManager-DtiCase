using MediatR;
using LeadsManager.backend.data;
using Microsoft.EntityFrameworkCore;
using LeadsManager.backend.Models;

public class GetInvitedLeadsQueryHandler : IRequestHandler<GetInvitedLeadsQuery, List<Lead>>
{
    private readonly AppDbContext _context;
    public GetInvitedLeadsQueryHandler(AppDbContext context) { _context = context; }

    public async Task<List<Lead>> Handle(GetInvitedLeadsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Leads.Where(l => l.Status == LeadStatus.Invited).ToListAsync();
    }
}
