using LeadsManager.backend.data;
using LeadsManager.backend.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeadsManager.backend.Controllers.Queries
{
    public class GetLeadByIdQueryHandler : IRequestHandler<GetLeadByIdQuery, LeadDto>
    {
        private readonly AppDbContext _context;

        public GetLeadByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LeadDto> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
        {

            var lead = await _context.Leads
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

            if (lead == null)
            {
                return null;
            }

            return new LeadDto
            {
                Id = lead.Id,
                FirstName = lead.FirstName,
                LastName = lead.LastName,
                ContactPhone = lead.ContactPhone,
                Email = lead.Email,
                DateCreated = lead.DateCreated,
                City = lead.City,
                Category = lead.Category,
                Description = lead.Description,
                Price = lead.Price,
                Status = lead.Status
            };
        }
    }
}