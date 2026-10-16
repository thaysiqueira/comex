using System;

public class Produto
{
	public string Nome { get; set; }
	public string Descricao { get; set; }
	public decimal PrecoUnitario { get; private set; }
	public int Quantidade { get; private set; }

	public Produto(string nome, string descricao, decimal precoUnitario, int quantidade)
	{
		if (string.IsNullOrWhiteSpace(nome))
			throw new ArgumentException("O nome do produto é obrigatório.", nameof(nome));

		if (precoUnitario <= 0)
			throw new ArgumentException("O preço unitário deve ser maior que zero.", nameof(precoUnitario));

		if (quantidade < 0)
			throw new ArgumentException("A quantidade não pode ser negativa.", nameof(quantidade));

		Nome = nome;
		Descricao = descricao;
		PrecoUnitario = precoUnitario;
		Quantidade = quantidade;
	}

	public void ExibirDescricao()
    {
        Console.WriteLine($"Nome: {Nome}, Descrição: {Descricao}, Preço Unitário: R$ {PrecoUnitario}, Quantidade: {Quantidade}");
    }

    public void AjustarPreco(decimal novoPreco)
	{
		if (novoPreco <= 0)
			throw new ArgumentException("O preço unitário deve ser maior que zero.", nameof(novoPreco));

		PrecoUnitario = novoPreco;
	}

	public void AjustarQuantidade(int novaQuantidade)
	{
		if (novaQuantidade < 0)
			throw new ArgumentException("A quantidade não pode ser negativa.", nameof(novaQuantidade));

		Quantidade = novaQuantidade;
	}
}
