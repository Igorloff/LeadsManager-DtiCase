using MediatR;
using LeadsManager.backend.data;
using Microsoft.EntityFrameworkCore;
using LeadsManager.backend.Models;

public class GetAcceptedLeadsQueryHandler : IRequestHandler<GetAcceptedLeadsQuery, List<Lead>>
{
    private readonly AppDbContext _context;
    public GetAcceptedLeadsQueryHandler(AppDbContext context) { _context = context; }

    public async Task<List<Lead>> Handle(GetAcceptedLeadsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Leads.Where(l => l.Status == LeadStatus.Accepted).ToListAsync();
    }
}
