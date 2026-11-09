using Services;

namespace Menus;

public class MenuAjustarPrecoProduto : Menu
{
    private readonly ProdutoService produtoService;

    public MenuAjustarPrecoProduto(ProdutoService produtoService)
        : base("Ajustar Preço do Produto")
    {
        this.produtoService = produtoService;
    }

    public override void Executar()
    {
        produtoService.AjustarPrecoProduto();
    }
}
