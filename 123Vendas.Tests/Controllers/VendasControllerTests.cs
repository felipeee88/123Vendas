using _123Vendas.API.Controllers;
using _123Vendas.Application.Commands.CancelarVenda;
using _123Vendas.Application.Commands.CriarVenda;
using _123Vendas.Application.Queries;
using _123Vendas.Domain.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace _123Vendas.Tests.Controllers
{
    public class VendasControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<VendasController>> _loggerMock;
        private readonly VendasController _controller;

        public VendasControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<VendasController>>();
            _controller = new VendasController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task CriarVenda_ReturnsOk_WhenVendaIsCreatedSuccessfully()
        {
            var venda = new Venda(DateTime.Now, "500");

            _mediatorMock.Setup(m => m.Send(It.IsAny<CriarVendasCommand>(), default))
                         .ReturnsAsync(venda);

            var result = await _controller.CriarVenda(venda);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(venda, okResult.Value);
        }

        [Fact]
        public async Task CriarVenda_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            var venda = new Venda(DateTime.Now, "500");
            
            _mediatorMock.Setup(m => m.Send(It.IsAny<CriarVendasCommand>(), default))
                         .ThrowsAsync(new Exception("Erro ao criar venda"));

            var result = await _controller.CriarVenda(venda);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task ObterVenda_ReturnsOk_WhenVendaExists()
        {
            var venda = new Venda(DateTime.Now, "500");
            venda.Id = 1;

            _mediatorMock.Setup(m => m.Send(It.IsAny<ObterVendasPorIdQuery>(), default))
                         .ReturnsAsync(venda);

            var result = await _controller.ObterVenda(venda.Id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(venda, okResult.Value);
        }

        [Fact]
        public async Task ObterVenda_ReturnsNotFound_WhenVendaDoesNotExist()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<ObterVendasPorIdQuery>(), default))
                         .ReturnsAsync((Venda)null);

            var result = await _controller.ObterVenda(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CancelarVenda_ReturnsOk_WhenVendaIsSuccessfullyCanceled()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<CancelarVendasCommand>(), default))
                         .ReturnsAsync(true);

            var result = await _controller.CancelarVenda(1);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CancelarVenda_ReturnsBadRequest_WhenCancellationFails()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<CancelarVendasCommand>(), default))
                         .ReturnsAsync(false);

            var result = await _controller.CancelarVenda(1);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
