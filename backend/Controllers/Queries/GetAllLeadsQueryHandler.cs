using MediatR;
using LeadsManager.backend.data;
using Microsoft.EntityFrameworkCore;
using LeadsManager.backend.Models;

public class GetAllLeadsQueryHandler : IRequestHandler<GetAllLeadsQuery, List<Lead>>
{
    private readonly AppDbContext _context;

    public GetAllLeadsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Lead>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Leads
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
    }
}
