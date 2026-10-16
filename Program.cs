using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static Dictionary<string, Cliente> clientes = new Dictionary<string, Cliente>();
    static Dictionary<string, Produto> produtos = new Dictionary<string, Produto>();
    static Dictionary<string, List<Produto>> produtosDoCarrinho = new Dictionary<string, List<Produto>>();

    static void Main()
    {
        string opcao = "";

        while (opcao != "-1")
        {
            try
            {
                ExibirMenuDeOpcoes();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        Console.WriteLine("COMEX FINALIZADO!");
    }

    static void ExibirMenuDeOpcoes()
    {   
        Console.WriteLine("============= PROJETO COMEX =============");
        Console.WriteLine("\nEscolha uma opção:");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Listar Clientes");
        Console.WriteLine("3 - Cadastrar Produto");
        Console.WriteLine("4 - Listar Produtos");
        Console.WriteLine("5 - Ajustar Preço do Produto");
        Console.WriteLine("6 - Adicionar Produto no Carrinho");
        Console.WriteLine("7 - Fechar Compra");
        Console.WriteLine("-1 - Sair");
        Console.Write("> ");

        string? opcao = Console.ReadLine();
        Console.WriteLine($"Opção escolhida: {opcao}");

        switch(opcao)
        {
            case "1":
                CadastrarCliente();
                break;
            case "2":
                ListarClientes();
                break;
            case "3":
                CadastrarProduto();
                break;
            case "4":
                ListarProdutos();
                break;
            case "5":
                AjustarPrecoProduto();
                break;
            case "6":
                AdicionarProdutoNoCarrinho();
                break;
            case "7":
                FecharCompra();
                break;
            case "-1":
                Console.WriteLine("COMEX FINALIZADO!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    static void CadastrarCliente()
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
        produtosDoCarrinho[cpf] = new List<Produto>();
        Console.WriteLine($"Usuário {nome} ({cpf}) cadastrado com sucesso.");
    }

    static void ListarClientes()
    {
        Console.WriteLine("\nLista de clientes cadastrados:\n");
        foreach (var cliente in clientes.Values)
        {
            cliente.ExibirDescricao();
        }
    }

    static void CadastrarProduto()
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

    static void ListarProdutos()
    {
        Console.WriteLine("\nLista de produtos cadastrados:\n");
        foreach (var produto in produtos.Values)
        {
            produto.ExibirDescricao();
        }
    }

    static void AjustarPrecoProduto()
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

    static void AdicionarProdutoNoCarrinho()
    {
        Console.Write("\nDigite o cpf do usuário que está comprando: ");
        string cpfUsuario = Console.ReadLine();

        if (!clientes.TryGetValue(cpfUsuario, out Cliente cliente))
        {
            Console.WriteLine($"Usuário {cpfUsuario} não cadastrado no sistema.");
            return;
        }

        Console.WriteLine("Produtos disponíveis:");
        foreach (var produto in produtos.Values)
        {
            produto.ExibirDescricao();
        }

        Console.Write("Digite o nome do produto que deseja adicionar ao carrinho: ");
        string nomeProduto = Console.ReadLine();

        if (!produtos.TryGetValue(nomeProduto, out Produto produtoEscolhido))
        {
            Console.WriteLine($"Produto {nomeProduto} não cadastrado no sistema.");
            return;
        }

        if (!produtosDoCarrinho.ContainsKey(cpfUsuario))
        {
            produtosDoCarrinho[cpfUsuario] = new List<Produto>();
        }

        produtosDoCarrinho[cpfUsuario].Add(produtoEscolhido);
        Console.WriteLine($"Produto {produtoEscolhido.Nome} adicionado ao carrinho de {cliente.Nome} com sucesso.");
    }

    private static void ExibirProdutosNoCarrinho(string cpfUsuario)
    {
        Console.WriteLine($"Produtos no carrinho do usuário {cpfUsuario}:");
        if (!produtosDoCarrinho.TryGetValue(cpfUsuario, out List<Produto> carrinho) || carrinho.Count == 0)
        {
            Console.WriteLine("Carrinho vazio.");
            return;
        }

        foreach (var produto in carrinho)
        {
            produto.ExibirDescricao();
        }
    }

    private static decimal CalcularValorFinalDaCompra(string cpfUsuario)
    {
        decimal valorTotal = 0;
        if (produtosDoCarrinho.TryGetValue(cpfUsuario, out List<Produto> carrinho))
        {
            foreach (var produto in carrinho)
            {
                valorTotal += produto.PrecoUnitario;
            }
        }

        Console.WriteLine($"Valor total da compra do usuário {cpfUsuario}: R$ {valorTotal}");
        return valorTotal;
    }

    static void FecharCompra()
    {
        Console.WriteLine("\nDigite o cpf do usuário que deseja finalizar a compra: ");
        string cpfUsuario = Console.ReadLine();

        if (!clientes.TryGetValue(cpfUsuario, out Cliente cliente))
        {
            Console.WriteLine($"Usuário {cpfUsuario} não cadastrado no sistema.");
            return;
        }

        ExibirProdutosNoCarrinho(cpfUsuario);
        decimal valorTotal = CalcularValorFinalDaCompra(cpfUsuario);

        Console.WriteLine("Digite o número do cartão:");
        string numeroCartao = Console.ReadLine();
        Console.WriteLine($"Realizando pagamento de R$ {valorTotal} no cartão {numeroCartao} para {cliente.Nome}.");
    }


}