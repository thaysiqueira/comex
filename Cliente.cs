using System;

public class Cliente
{
	public string Nome { get; private set; }
	public string CPF { get; }
	public string Email { get; private set; }
	public string Profissao { get; private set; }
	public string Telefone { get; private set; }
	public Endereco Endereco { get; private set; }

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
}
