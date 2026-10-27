using Models;
using System;

public class ProdutoEletronico : Produto
{
	public ProdutoEletronico(string nome, string descricao, decimal precoUnitario, int quantidade,
        int voltagem, int potencia)
        : base(nome, descricao, precoUnitario, quantidade)
    {
		Voltagem = voltagem;
        Potencia = potencia;
    }

    public int Voltagem { get; private set; }
    public int Potencia { get; private set; }

    public override void ExibirDescricao()
    {
        Console.WriteLine($"Voltagem: {Voltagem}V, Potência: {Potencia}W");
    }
}
