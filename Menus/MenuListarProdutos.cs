using Services;

namespace Menus;

public class MenuListarProdutos : Menu
{
    private readonly ProdutoService produtoService;

    public MenuListarProdutos(ProdutoService produtoService)
        : base("Listar Produtos")
    {
        this.produtoService = produtoService;
    }

    public override void Executar()
    {
        produtoService.ListarProdutos();
    }
}
