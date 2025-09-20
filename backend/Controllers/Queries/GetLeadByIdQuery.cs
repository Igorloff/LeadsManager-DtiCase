using MediatR;
using LeadsManager.backend.Dtos;

public record GetLeadByIdQuery(int Id) : IRequest<LeadDto>;