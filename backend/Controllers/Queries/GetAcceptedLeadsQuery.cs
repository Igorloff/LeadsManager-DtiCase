using MediatR;
using LeadsManager.backend.Models;
using System.Collections.Generic;

public record GetAcceptedLeadsQuery() : IRequest<List<Lead>>;
