using MediatR;
using LeadsManager.backend.Models;
using System.Collections.Generic;

public record GetInvitedLeadsQuery() : IRequest<List<Lead>>;
