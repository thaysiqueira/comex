using System;
using System.Collections.Generic;
using Models;

namespace Services;

public class ClienteService
{
    private readonly Dictionary<string, Cliente> clientes = new Dictionary<string, Cliente>();

    public void CadastrarCliente()
    {
        Console.Write("\nDigite o nome do cliente: ");
        string? nome = Console.ReadLine();
        Console.Write("Digite o CPF do cliente: ");
        string? cpf = Console.ReadLine();
        Console.Write("Digite o e-mail do cliente: ");
        string? email = Console.ReadLine();
        Console.Write("Digite a profissão do cliente: ");
        string? profissao = Console.ReadLine();
        Console.Write("Digite o telefone do cliente: ");
        string? telefone = Console.ReadLine();

        Console.Write("Digite o estado: ");
        string? estado = Console.ReadLine();
        Console.Write("Digite a cidade: ");
        string? cidade = Console.ReadLine();
        Console.Write("Digite o bairro: ");
        string? bairro = Console.ReadLine();
        Console.Write("Digite a rua: ");
        string? rua = Console.ReadLine();
        Console.Write("Digite o número: ");
        string? numero = Console.ReadLine();
        Console.Write("Digite o complemento (opcional): ");
        string? complemento = Console.ReadLine();

        var endereco = new Endereco(estado, cidade, bairro, rua, numero, complemento ?? "");

        clientes[cpf] = new Cliente(nome, cpf, email, profissao, telefone, endereco);
        Console.WriteLine($"Usuário {nome} ({cpf}) cadastrado com sucesso.");
    }

    public void ListarClientes()
    {
        Console.WriteLine("\nLista de clientes cadastrados:\n");
        foreach (var cliente in clientes.Values)
        {
            cliente.ExibirDescricao();
        }
    }

    public void AdicionarProdutoNoCarrinho(ProdutoService produtoService)
    {
        Console.Write("\nDigite o cpf do usuário que está comprando: ");
        string cpfUsuario = Console.ReadLine();

        if (!clientes.TryGetValue(cpfUsuario, out Cliente cliente))
        {
            Console.WriteLine($"Usuário {cpfUsuario} não cadastrado no sistema.");
            return;
        }

        Console.WriteLine("Produtos disponíveis:");
        foreach (var produto in produtoService.Produtos.Values)
        {
            produto.ExibirDescricao();
        }

        Console.Write("Digite o nome do produto que deseja adicionar ao carrinho: ");
        string nomeProduto = Console.ReadLine();

        if (!produtoService.TryObterProduto(nomeProduto, out Produto produtoEscolhido))
        {
            Console.WriteLine($"Produto {nomeProduto} não cadastrado no sistema.");
            return;
        }

        if (produtoEscolhido.Quantidade <= 0)
        {
            Console.WriteLine($"Produto {produtoEscolhido.Nome} está sem estoque.");
            return;
        }

        cliente.AdicionarAoCarrinho(produtoEscolhido);
        produtoEscolhido.AjustarQuantidade(produtoEscolhido.Quantidade - 1);
        Console.WriteLine($"Produto {produtoEscolhido.Nome} adicionado ao carrinho de {cliente.Nome} com sucesso.");
    }

    private void ExibirProdutosNoCarrinho(Cliente cliente)
    {
        Console.WriteLine($"Produtos no carrinho do usuário {cliente.CPF}:");
        if (cliente.Carrinho.Count == 0)
        {
            Console.WriteLine("Carrinho vazio.");
            return;
        }

        foreach (var item in cliente.Carrinho)
        {
            item.Produto.ExibirDescricao();
            Console.WriteLine($"  -> Quantidade no carrinho: {item.Quantidade} | Subtotal: {item.Subtotal:C}");
        }
    }

    private decimal CalcularValorFinalDaCompra(Cliente cliente)
    {
        decimal valorTotal = 0;
        foreach (var item in cliente.Carrinho)
        {
            valorTotal += item.Subtotal;
        }

        return valorTotal;
    }

    public void FecharCompra()
    {
        Console.WriteLine("\nDigite o cpf do usuário que deseja finalizar a compra: ");
        string? cpfUsuario = Console.ReadLine();

        if (cpfUsuario is null || !clientes.TryGetValue(cpfUsuario, out Cliente cliente))
        {
            Console.WriteLine($"Usuário {cpfUsuario} não cadastrado no sistema.");
            return;
        }

        ExibirProdutosNoCarrinho(cliente);
        decimal valorTotal = CalcularValorFinalDaCompra(cliente);
        Console.WriteLine($"Valor total da compra do usuário {cliente.CPF}: {valorTotal:C}");

        Console.WriteLine("Digite o número do cartão:");
        string? numeroCartao = Console.ReadLine();
        Console.WriteLine($"Realizando pagamento de {valorTotal:C} no cartão {numeroCartao} para {cliente.Nome}.");

        cliente.LimparCarrinho();
    }
}
