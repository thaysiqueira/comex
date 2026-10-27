using System;
using Services;

public class Menu
{
    private readonly ClienteService clienteService = new ClienteService();
    private readonly ProdutoService produtoService = new ProdutoService();

    public void Executar()
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

    private void ExibirMenuDeOpcoes()
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

        switch (opcao)
        {
            case "1":
                clienteService.CadastrarCliente();
                break;
            case "2":
                clienteService.ListarClientes();
                break;
            case "3":
                produtoService.CadastrarProduto();
                break;
            case "4":
                produtoService.ListarProdutos();
                break;
            case "5":
                produtoService.AjustarPrecoProduto();
                break;
            case "6":
                clienteService.AdicionarProdutoNoCarrinho(produtoService);
                break;
            case "7":
                clienteService.FecharCompra();
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
}
