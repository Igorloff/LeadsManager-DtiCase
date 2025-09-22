using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using LeadsManager.backend.Dtos;

public class LeadsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly LeadsController _controller;

    public LeadsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new LeadsController(_mediatorMock.Object);
    }

    [Fact]
    public async Task AddLead_ReturnsCreatedAtAction()
    {
        var dto = new LeadCreateDto { FirstName = "Igor", LastName = "Reis" };
        var returnedLead = new { Id = 1, FirstName = "Igor", LastName = "Reis" };
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<AddLeadCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(returnedLead);

        var result = await _controller.AddLead(dto);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetById), createdResult.ActionName);
    }

    [Fact]
    public async Task UpdateLead_ReturnsNoContent_WhenSuccess()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<UpdateLeadCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.UpdateLead(1, new LeadCreateDto());

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task UpdateLead_ReturnsNotFound_WhenFail()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<UpdateLeadCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var result = await _controller.UpdateLead(1, new LeadCreateDto());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteById_ReturnsNoContent_WhenSuccess()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteLeadCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.DeleteById(1);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteById_ReturnsNotFound_WhenFail()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteLeadCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var result = await _controller.DeleteById(1);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task AcceptLead_ReturnsOk_WhenLeadExists()
    {
        var lead = new { Id = 1 };
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<AcceptLeadCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(lead);

        var result = await _controller.AcceptLead(1);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task AcceptLead_ReturnsNotFound_WhenLeadNull()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<AcceptLeadCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((object)null);

        var result = await _controller.AcceptLead(1);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetById_ReturnsOk_WhenLeadExists()
    {
        var lead = new { Id = 1 };
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetLeadByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(lead);

        var result = await _controller.GetById(1);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenLeadNull()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetLeadByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((object)null);

        var result = await _controller.GetById(1);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetAll_ReturnsOk()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllLeadsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new[] { new { Id = 1 }, new { Id = 2 } });

        var result = await _controller.GetAll();

        Assert.IsType<OkObjectResult>(result);
    }
}
