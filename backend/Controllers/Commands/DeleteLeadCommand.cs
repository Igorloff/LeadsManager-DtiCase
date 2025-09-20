using MediatR;

public record DeleteLeadCommand(int Id) : IRequest<bool>;
