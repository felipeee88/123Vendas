using _123Vendas.Domain.Entidades;
using FluentAssertions;
using Moq;
using Xunit;
using System.Threading.Tasks;
using System;
using _123Vendas.Domain.Interface.Repository;
using _123Vendas.Domain.Service;
using _123Vendas.Domain.Interface.Service;
using Microsoft.Extensions.Logging;

namespace _123Vendas.Tests.Service
{
    public class VendaServiceTests
    {
        private readonly Mock<IVendasRepository> _vendaRepositoryMock;
        private readonly VendasService _vendaService;
        private readonly Mock<ILogger<VendasService>> _loggerMock;

        public VendaServiceTests()
        {
            _vendaRepositoryMock = new Mock<IVendasRepository>();
            _loggerMock = new Mock<ILogger<VendasService>>();
            _vendaService = new VendasService(_vendaRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task CriarVendaAsync_ThrowsArgumentNullException_WhenVendaIsNull()
        {
            Func<Task> act = async () => await _vendaService.CriarVendaAsync(null);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task CriarVendaAsync_ReturnsVenda_WhenVendaIsCreated()
        {
            var venda = new Venda(DateTime.Now, "500");

            _vendaRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Venda>()))
                                .Returns((Task<Venda>)Task.CompletedTask);

            var result = await _vendaService.CriarVendaAsync(venda);

            result.Should().Be(venda);
        }

        [Fact]
        public async Task CancelarVendaAsync_ReturnsFalse_WhenVendaDoesNotExist()
        {
            _vendaRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                                .ReturnsAsync((Venda)null);

            var result = await _vendaService.CancelarVendaAsync(1);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task CancelarVendaAsync_ReturnsTrue_WhenVendaIsCanceled()
        {
            var venda = new Venda(DateTime.Now, "500");
            venda.IsCanceled = false;

            _vendaRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                                .ReturnsAsync(venda);
            _vendaRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Venda>()))
                                .ReturnsAsync(true);

            var result = await _vendaService.CancelarVendaAsync(1);

            result.Should().BeTrue();
            venda.IsCanceled.Should().BeTrue();
        }
    }
}
