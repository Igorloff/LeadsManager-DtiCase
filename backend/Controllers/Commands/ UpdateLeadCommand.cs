using MediatR;
using LeadsManager.backend.Dtos;

public record UpdateLeadCommand(int Id, LeadCreateDto LeadDto) : IRequest<bool>;
    