namespace Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class Cliente : IDescritivel
{
	public string Nome { get; private set; }
	public string CPF { get; }
	public string Email { get; private set; }
	public string Profissao { get; private set; }
	public string Telefone { get; private set; }
	public Endereco Endereco { get; private set; }

	private readonly List<ItemCarrinho> carrinho = new List<ItemCarrinho>();
	public IReadOnlyList<ItemCarrinho> Carrinho => carrinho;

	public Cliente(string nome, string cpf, string email, string profissao, string telefone, Endereco endereco)
	{
		if (string.IsNullOrWhiteSpace(nome))
			throw new ArgumentException("O nome do cliente é obrigatório.", nameof(nome));

		if (string.IsNullOrWhiteSpace(cpf))
			throw new ArgumentException("O CPF do cliente é obrigatório.", nameof(cpf));

		if (string.IsNullOrWhiteSpace(email))
			throw new ArgumentException("O e-mail do cliente é obrigatório.", nameof(email));

		if (endereco is null)
			throw new ArgumentNullException(nameof(endereco), "O endereço do cliente é obrigatório.");

		Nome = nome;
		CPF = cpf;
		Email = email;
        Profissao = profissao;
        Telefone = telefone;
        Endereco = endereco;
    }

	public void ExibirDescricao()
	{
		Console.WriteLine($"Nome: {Nome}, CPF: {CPF}, E-mail: {Email}, Profissão: {Profissao}, Telefone: {Telefone}, Endereço: {Endereco}");
	}

	public void AdicionarAoCarrinho(Produto produto)
	{
		if (produto is null)
			throw new ArgumentNullException(nameof(produto));

		var itemExistente = carrinho.FirstOrDefault(item => item.Produto == produto);
		if (itemExistente is null)
			carrinho.Add(new ItemCarrinho(produto));
		else
			itemExistente.IncrementarQuantidade();
	}

	public void LimparCarrinho()
	{
		carrinho.Clear();
	}
}
