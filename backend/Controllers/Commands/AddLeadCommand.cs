using MediatR;
using LeadsManager.backend.Dtos;
using LeadsManager.backend.Models;

public record AddLeadCommand(LeadCreateDto LeadDto) : IRequest<Lead>;
