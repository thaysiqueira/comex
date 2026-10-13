using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static Dictionary<string, string> clientes = new Dictionary<string, string>();
    static Dictionary<string, decimal> produtos = new Dictionary<string, decimal>();
    static Dictionary<string, List<string>> produtosDoCarrinho = new Dictionary<string, List<string>>();

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
        Console.WriteLine("4 - Ajustar Preço do Produto");
        Console.WriteLine("5 - Adicionar Produto no Carrinho");
        Console.WriteLine("6 - Fechar Compra");
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
                AjustarPrecoProduto();
                break;
            case "5":
                AdicionarProdutoNoCarrinho();
                break;
            case "6":
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

        if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(cpf))
        {
            clientes[cpf] = nome;
            produtosDoCarrinho[cpf] = new List<string>();
            Console.WriteLine($"Usuário {nome} ({cpf}) cadastrado com sucesso.");
        }
        else
        {
            Console.WriteLine("Nome e CPF não podem estar vazios!");
        }
    }

    static void ListarClientes()
    {
        Console.WriteLine("\nLista de clientes cadastrados:\n");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Value}, CPF: {cliente.Key}");
        }
    }

    static void CadastrarProduto()
    {
        Console.Write("\nDigite o nome do produto: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o preço do produto: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
        {
            Console.WriteLine("Preço inválido.");
            return;
        }

        produtos[nome] = preco;

        Console.WriteLine($"Produto {nome} cadastrado com sucesso.");
    }

    static void AjustarPrecoProduto()
    {
        Console.WriteLine("Produtos disponíveis:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"- {produto.Key}: R$ {produto.Value}");
        }
        Console.Write("\nQual produto você deseja ajustar o preço?");
        string nome = Console.ReadLine();
        if (produtos.ContainsKey(nome))
        {
            Console.Write("Digite o novo preço do produto: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal novoPreco))
            {
                Console.WriteLine("Preço inválido.");
                return;
            }
            produtos[nome] = novoPreco;
            Console.WriteLine($"Preço do produto {nome} ajustado para {novoPreco} com sucesso.");
        }
        else
        {
            Console.WriteLine($"Produto {nome} não cadastrado no sistema.");
        }
    }

    static void AdicionarProdutoNoCarrinho()
    {
        Console.Write("\nDigite o nome do usuário que está comprando: ");
        string nomeUsuario = Console.ReadLine();
        if (clientes.ContainsValue(nomeUsuario))
        {
            Console.WriteLine("Produtos disponíveis:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"- {produto.Key}: R$ {produto.Value}");
            }
            Console.Write("Digite o nome do produto que deseja adicionar ao carrinho: ");
            string nomeProduto = Console.ReadLine();
            if (produtos.ContainsKey(nomeProduto))
            {
                if (!produtosDoCarrinho.ContainsKey(nomeUsuario))
                {
                    produtosDoCarrinho[nomeUsuario] = new List<string>();
                }
                produtosDoCarrinho[nomeUsuario].Add(nomeProduto);
                Console.WriteLine($"Produto {nomeProduto} adicionado ao carrinho do usuário {nomeUsuario} com sucesso.");
            }
            else
            {
                Console.WriteLine($"Produto {nomeProduto} não cadastrado no sistema.");
            }
        }
        else
        {
            Console.WriteLine($"Usuário {nomeUsuario} não cadastrado no sistema.");
        }


    }

    private static void ExibirProdutosNoCarrinho(string nomeUsuario)
    {
        Console.WriteLine($"Produtos no carrinho do usuário {nomeUsuario}:");
        foreach (var item in produtosDoCarrinho)
        {
            if (item.Key == nomeUsuario)
            {
                foreach (var produto in item.Value)
                {
                    Console.WriteLine($"\n{produto}");
                }
            }
        }
    }

    private static decimal CalcularValorFinalDaCompra(string nomeUsuario)
    {
        decimal valorTotal = 0;
        foreach (var produto in produtosDoCarrinho)
        {
            if (produto.Key == nomeUsuario)
            {
                foreach (string nomeProduto in produto.Value)
                {
                    if (produtos.ContainsKey(nomeProduto))
                    {
                        decimal precoProduto = produtos[nomeProduto];
                        valorTotal += precoProduto;
                    }
                }
            }
        }
        Console.WriteLine($"Valor total da compra do usuário {nomeUsuario}: R$ {valorTotal}");
        return valorTotal;
    }

    static void FecharCompra()
    {
        Console.WriteLine("\nDigite o nome do usuário que deseja finalizar a compra: ");
        string nomeUsuario = Console.ReadLine();
            if (clientes.ContainsValue(nomeUsuario))
            {
            ExibirProdutosNoCarrinho(nomeUsuario);
            decimal valorTotal = CalcularValorFinalDaCompra(nomeUsuario);

            Console.WriteLine("Digite o número do cartão:");
            string numeroCartao = Console.ReadLine();
            Console.WriteLine($"Realizando pagamento de R$ {valorTotal} no cartão {numeroCartao}.");
            }
            else
            {
                Console.WriteLine($"Usuário {nomeUsuario} não cadastrado no sistema.");
            }
    }


}