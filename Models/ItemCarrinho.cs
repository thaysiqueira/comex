namespace Models;
using System;

public class ItemCarrinho
{
    public Produto Produto { get; }
    public int Quantidade { get; private set; }

    public decimal Subtotal => Produto.PrecoUnitario * Quantidade;

    public ItemCarrinho(Produto produto, int quantidade = 1)
    {
        if (produto is null)
            throw new ArgumentNullException(nameof(produto));

        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));

        Produto = produto;
        Quantidade = quantidade;
    }

    public void IncrementarQuantidade(int quantidade = 1)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));

        Quantidade += quantidade;
    }
}
