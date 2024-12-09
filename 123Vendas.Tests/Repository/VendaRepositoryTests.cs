using _123Vendas.Domain.Entidades;
using _123Vendas.Infra.Context;
using _123Vendas.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace _123Vendas.Tests.Repository
{
    public class VendaRepositoryTests
    {
        private readonly Mock<VendasContext> _mockContext;
        private readonly VendasRepository _repository;
        private readonly Mock<DbSet<Venda>> _mockSet;

        public VendaRepositoryTests()
        {
            _mockContext = new Mock<VendasContext>();
            _mockSet = new Mock<DbSet<Venda>>();
            _mockContext.Setup(m => m.Vendas).Returns(_mockSet.Object);
            _repository = new VendasRepository(_mockContext.Object);
        }

        [Fact]
        public async Task AddAsync_AddsVenda()
        {
            var venda = new Venda(DateTime.Now, "500");
            await _repository.AddAsync(venda);
            _mockSet.Verify(m => m.Add(It.IsAny<Venda>()), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsVenda_WhenVendaExists()
        {
            var venda = new Venda(DateTime.Now, "500");
            venda.Id = 1;
            _mockSet.Setup(m => m.FindAsync(1)).ReturnsAsync(venda);
            var result = await _repository.GetByIdAsync(1);
            Assert.Equal(venda, result);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesVenda()
        {
            var venda = new Venda(DateTime.Now, "500");
            venda.Id = 1;
            _mockContext.Setup(m => m.Vendas.Update(venda));
            _mockContext.Setup(m => m.SaveChangesAsync(default)).ReturnsAsync(1);
            var result = await _repository.UpdateAsync(venda);
            Assert.True(result);
        }
    }
}
