using System;
using System.Collections.Generic;
using Models;

namespace Services;

public class ProdutoService
{
    private readonly Dictionary<string, Produto> produtos = new Dictionary<string, Produto>();

    public IReadOnlyDictionary<string, Produto> Produtos => produtos;

    public bool TryObterProduto(string nome, out Produto produto)
    {
        return produtos.TryGetValue(nome, out produto);
    }

    public void CadastrarProduto()
    {
        Console.Write("\nDigite o nome do produto: ");
        string nome = Console.ReadLine();
        Console.Write("Digite a descrição do produto: ");
        string descricao = Console.ReadLine();
        Console.Write("Digite o preço do produto: ");
        decimal preco = decimal.Parse(Console.ReadLine());
        Console.Write("Digite a quantidade do produto: ");
        int quantidade = int.Parse(Console.ReadLine());

        produtos[nome] = new Produto(nome, descricao, preco, quantidade);
        Console.WriteLine($"Produto {nome} cadastrado com sucesso.");
    }

    public void ListarProdutos()
    {
        Console.WriteLine("\nLista de produtos cadastrados:\n");
        foreach (var produto in produtos.Values)
        {
            produto.ExibirDescricao();
        }
    }

    public void AjustarPrecoProduto()
    {
        Console.Write("\nQual produto você deseja ajustar o preço?");
        string nome = Console.ReadLine();
        if (!produtos.TryGetValue(nome, out Produto produto))
        {
            Console.WriteLine($"Produto {nome} não cadastrado no sistema.");
            return;
        }

        Console.Write("Digite o novo preço do produto: ");
        decimal novoPreco = decimal.Parse(Console.ReadLine());

        produto.AjustarPreco(novoPreco);
        Console.WriteLine($"Preço do produto {produto.Nome} ajustado para {novoPreco} com sucesso.");
    }
}
