using _123Vendas.Domain.Entidades;
using _123Vendas.Domain.Interface.Repository;
using _123Vendas.Domain.Interface.Service;
using Microsoft.Extensions.Logging;

namespace _123Vendas.Domain.Service
{
    public class VendasService : IVendasService
    {
        private readonly IVendasRepository _vendaRepository;
        private readonly ILogger<VendasService> _logger;

        public VendasService(IVendasRepository vendaRepository, ILogger<VendasService> logger)
        {
            _vendaRepository = vendaRepository;
            _logger = logger;
        }

        public async Task<Venda> CriarVendaAsync(Venda venda)
        {
            try
            {
                foreach (var item in venda.Itens)
                {
                    item.CalcularDesconto();
                }

                venda.RecalcularTotalVenda();
                return await _vendaRepository.AddAsync(venda);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar venda: {ex.Message}", ex);
                throw;
            }
        }

        public async Task<bool> AtualizarVendaAsync(Venda venda)
        {
            try
            {
                foreach (var item in venda.Itens)
                {
                    item.CalcularDesconto();
                }
                venda.RecalcularTotalVenda();
                return await _vendaRepository.UpdateAsync(venda);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar venda: {ex.Message}", ex);
                throw;
            }
        }

        public async Task<bool> CancelarVendaAsync(int vendaId)
        {
            try
            {
                var venda = await _vendaRepository.GetByIdAsync(vendaId);
                if (venda == null)
                {
                    _logger.LogError("Venda não encontrada para cancelamento.");
                    return false;
                }

                venda.CancelarVenda();
                return await _vendaRepository.UpdateAsync(venda);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao cancelar venda: {ex.Message}", ex);
                throw;
            }
        }

        public async Task<Venda> ObterVendaPorIdAsync(int vendaId)
        {
            try
            {
                return await _vendaRepository.GetByIdAsync(vendaId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter venda por ID: {ex.Message}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<Venda>> ListarTodasVendasAsync()
        {
            try
            {
                return await _vendaRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar todas as vendas: {ex.Message}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<Venda>> ListarVendasPorClienteIdAsync(string clienteId)
        {
            try
            {
                return await _vendaRepository.GetByClienteIdAsync(clienteId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar vendas por cliente ID: {ex.Message}", ex);
                throw;
            }
        }
    }
}
