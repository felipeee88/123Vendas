using _123Vendas.Application.Commands.AtualizarVenda;
using _123Vendas.Application.Commands.CancelarVenda;
using _123Vendas.Application.Commands.CriarVenda;
using _123Vendas.Application.Queries;
using _123Vendas.Domain.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _123Vendas.API.Controllers
{
    [ApiController]
    [Route("api/vendas")]
    public class VendasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<VendasController> _logger;

        public VendasController(IMediator mediator, ILogger<VendasController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CriarVenda([FromBody] Venda venda)
        {
            _logger.LogInformation("Requisição para criar uma nova venda recebida.");
            try
            {
                var result = await _mediator.Send(new CriarVendasCommand(venda));
                _logger.LogInformation("Venda criada com sucesso com ID {VendaId}", result.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar venda.");
                return BadRequest("Não foi possível criar a venda");
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarVenda([FromBody] Venda venda)
        {
            _logger.LogInformation("Requisição para atualizar a venda ID {VendaId} recebida.", venda.Id);
            try
            {
                var result = await _mediator.Send(new AtualizarVendasCommand(venda));
                if (result)
                {
                    _logger.LogInformation("Venda ID {VendaId} atualizada com sucesso.", venda.Id);
                    return Ok();
                }
                _logger.LogWarning("Falha ao tentar atualizar a venda ID {VendaId}.", venda.Id);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar a venda ID {VendaId}.", venda.Id);
                return BadRequest("Erro ao atualizar a venda");
            }
        }

        [HttpPost("cancelar/{id}")]
        public async Task<IActionResult> CancelarVenda(int id)
        {
            _logger.LogInformation("Requisição para cancelar a venda ID {VendaId} recebida.", id);
            try
            {
                var result = await _mediator.Send(new CancelarVendasCommand(id));
                if (result)
                {
                    _logger.LogInformation("Venda ID {VendaId} cancelada com sucesso.", id);
                    return Ok();
                }
                _logger.LogWarning("Falha ao tentar cancelar a venda ID {VendaId}.", id);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cancelar a venda ID {VendaId}.", id);
                return BadRequest("Erro ao cancelar a venda");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterVenda(int id)
        {
            _logger.LogInformation("Requisição para obter a venda ID {VendaId} recebida.", id);
            try
            {
                var venda = await _mediator.Send(new ObterVendasPorIdQuery(id));
                if (venda != null)
                {
                    _logger.LogInformation("Venda ID {VendaId} obtida com sucesso.", id);
                    return Ok(venda);
                }
                _logger.LogWarning("Venda ID {VendaId} não encontrada.", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter a venda ID {VendaId}.", id);
                return BadRequest("Erro ao obter a venda");
            }
        }

        [HttpGet("todas")]
        public async Task<IActionResult> ListarTodasVendas()
        {
            _logger.LogInformation("Requisição para listar todas as vendas recebida.");
            try
            {
                var vendas = await _mediator.Send(new ListarTodasVendasQuery());
                _logger.LogInformation("Listagem de todas as vendas realizada com sucesso.");
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar todas as vendas.");
                return BadRequest("Erro ao listar vendas");
            }
        }

        [HttpGet("por-cliente/{clienteId}")]
        public async Task<IActionResult> ListarVendasPorClienteId(string clienteId)
        {
            _logger.LogInformation("Requisição para listar vendas do cliente ID {ClienteId} recebida.", clienteId);
            try
            {
                var vendas = await _mediator.Send(new ListarVendasPorClienteIdQuery(clienteId));
                _logger.LogInformation("Listagem de vendas para o cliente ID {ClienteId} realizada com sucesso.", clienteId);
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar vendas para o cliente ID {ClienteId}.", clienteId);
                return BadRequest("Erro ao listar vendas para o cliente");
            }
        }
    }
}
