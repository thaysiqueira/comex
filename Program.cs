using System.Globalization;
using Menus;
using Services;

System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

var clienteService = new ClienteService();
var produtoService = new ProdutoService();
var apiExternaService = new ApiExternaService();

var menus = new Dictionary<string, Menu>
{
    { "1", new MenuCadastrarCliente(clienteService) },
    { "2", new MenuListarClientes(clienteService) },
    { "3", new MenuCadastrarProduto(produtoService) },
    { "4", new MenuListarProdutos(produtoService) },
    { "5", new MenuAjustarPrecoProduto(produtoService) },
    { "6", new MenuAdicionarProdutoNoCarrinho(clienteService, produtoService) },
    { "7", new MenuFecharCompra(clienteService) },
    { "8", new MenuBuscarProdutosExternos(apiExternaService) },
    { "9", new MenuOrdenarProdutosPorNome(apiExternaService) },
    { "10", new MenuOrdenarProdutosPorPreco(apiExternaService) },
    { "11", new MenuGerarRelatorioCsv() },
};

new AplicacaoComex(menus).Executar();