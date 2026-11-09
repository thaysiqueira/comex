using Services;

namespace Menus;

public class MenuAdicionarProdutoNoCarrinho : Menu
{
    private readonly ClienteService clienteService;
    private readonly ProdutoService produtoService;

    public MenuAdicionarProdutoNoCarrinho(ClienteService clienteService, ProdutoService produtoService)
        : base("Adicionar Produto no Carrinho")
    {
        this.clienteService = clienteService;
        this.produtoService = produtoService;
    }

    public override void Executar()
    {
        clienteService.AdicionarProdutoNoCarrinho(produtoService);
    }
}
