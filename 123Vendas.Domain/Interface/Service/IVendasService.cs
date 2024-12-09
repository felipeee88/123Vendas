using _123Vendas.Domain.Entidades;

namespace _123Vendas.Domain.Interface.Service
{
    public interface IVendasService
    {
        Task<Venda> CriarVendaAsync(Venda venda);
        Task<bool> AtualizarVendaAsync(Venda venda);
        Task<bool> CancelarVendaAsync(int vendaId);
        Task<Venda> ObterVendaPorIdAsync(int vendaId);
        Task<IEnumerable<Venda>> ListarTodasVendasAsync();
        Task<IEnumerable<Venda>> ListarVendasPorClienteIdAsync(string clienteId);
    }
}
