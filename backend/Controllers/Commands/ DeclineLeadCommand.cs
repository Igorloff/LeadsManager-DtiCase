using LeadsManager.backend.Models;
using MediatR;

public record DeclineLeadCommand(int Id) : IRequest<Lead>;
