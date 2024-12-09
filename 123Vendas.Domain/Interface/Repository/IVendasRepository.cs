using _123Vendas.Domain.Entidades;

namespace _123Vendas.Domain.Interface.Repository
{
    public interface IVendasRepository
    {
        Task<Venda> AddAsync(Venda venda);
        Task<bool> UpdateAsync(Venda venda);
        Task<bool> DeleteAsync(int vendaId);
        Task<Venda> GetByIdAsync(int vendaId);
        Task<IEnumerable<Venda>> GetAllAsync();
        Task<IEnumerable<Venda>> GetByClienteIdAsync(string clienteId);
        Task<IEnumerable<Venda>> GetByPeriodoAsync(DateTime inicio, DateTime fim);
        Task<IEnumerable<Venda>> GetCanceladasAsync();
    }
}
