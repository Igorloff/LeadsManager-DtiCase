using LeadsManager.backend.Models;
using MediatR;

public record AcceptLeadCommand(int Id) : IRequest<Lead>;
