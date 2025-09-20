using MediatR;
using LeadsManager.backend.Models;
using System.Collections.Generic;

public record GetAllLeadsQuery(int Page, int PageSize) : IRequest<List<Lead>>;
