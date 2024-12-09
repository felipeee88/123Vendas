namespace _123Vendas.Domain.Entidades
{
    public class Item
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }

        public Item(int produtoId, int quantidade, decimal precoUnitario)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            CalcularDesconto();
        }

        public void CalcularDesconto()
        {
            if (Quantidade > 20)
            {
                throw new InvalidOperationException("Não é possível vender mais de 20 itens iguais.");
            }
            else if (Quantidade >= 10)
            {
                Desconto = (PrecoUnitario * Quantidade) * 0.20m;
            }
            else if (Quantidade >= 4)
            {
                Desconto = (PrecoUnitario * Quantidade) * 0.10m;
            }
            else
            {
                Desconto = 0;
            }
        }

        public decimal CalcularValorTotal()
        {
            return (PrecoUnitario * Quantidade) - Desconto;
        }
    }
}
