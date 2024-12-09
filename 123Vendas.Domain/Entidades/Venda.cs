namespace _123Vendas.Domain.Entidades
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public string ClienteId { get; set; }
        public decimal TotalVenda { get; set; }
        public List<Item> Itens { get; set; }
        public bool IsCanceled { get; set; }


        public Venda(DateTime dataVenda, string clienteId)
        {
            DataVenda = dataVenda;
            ClienteId = clienteId;
            Itens = new List<Item>();
            IsCanceled = false;
        }

        public void AdicionarItem(Item item)
        {
            Itens.Add(item);
            RecalcularTotalVenda();
        }

        public void AtualizarItem(int produtoId, int novaQuantidade)
        {
            var item = Itens.FirstOrDefault(i => i.ProdutoId == produtoId);
            if (item != null)
            {
                item.Quantidade = novaQuantidade;
                item.CalcularDesconto();
                RecalcularTotalVenda();
            }
        }

        public void RecalcularTotalVenda()
        {
            TotalVenda = Itens.Sum(item => item.CalcularValorTotal());
        }

        public void CancelarVenda()
        {
            IsCanceled = true;
        }
    }
}
