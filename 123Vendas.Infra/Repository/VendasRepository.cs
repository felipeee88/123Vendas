using _123Vendas.Domain.Entidades;
using _123Vendas.Domain.Interface.Repository;
using _123Vendas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Infra.Repository
{
    public class VendasRepository : IVendasRepository
    {
        private readonly VendasContext _context;

        public VendasRepository(VendasContext context)
        {
            _context = context;
        }

        public async Task<Venda> AddAsync(Venda venda)
        {
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<bool> UpdateAsync(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int vendaId)
        {
            var venda = await _context.Vendas.FindAsync(vendaId);
            if (venda == null) return false;
            _context.Vendas.Remove(venda);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Venda> GetByIdAsync(int vendaId) => await _context.Vendas
                .Include(v => v.Itens)
                .FirstOrDefaultAsync(v => v.Id == vendaId);

        public async Task<IEnumerable<Venda>> GetAllAsync() => await _context.Vendas
                .Include(v => v.Itens)
                .ToListAsync();

        public async Task<IEnumerable<Venda>> GetByClienteIdAsync(string clienteId) => await _context.Vendas
                .Where(v => v.ClienteId == clienteId)
                .Include(v => v.Itens)
                .ToListAsync();

        public async Task<IEnumerable<Venda>> GetByPeriodoAsync(DateTime inicio, DateTime fim) => await _context.Vendas
                .Where(v => v.DataVenda >= inicio && v.DataVenda <= fim)
                .Include(v => v.Itens)
                .ToListAsync();

        public async Task<IEnumerable<Venda>> GetCanceladasAsync() => await _context.Vendas
                .Where(v => v.IsCanceled)
                .Include(v => v.Itens)
                .ToListAsync();
    }
}
