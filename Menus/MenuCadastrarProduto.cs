using Services;

namespace Menus;

public class MenuCadastrarProduto : Menu
{
    private readonly ProdutoService produtoService;

    public MenuCadastrarProduto(ProdutoService produtoService)
        : base("Cadastrar Produto")
    {
        this.produtoService = produtoService;
    }

    public override void Executar()
    {
        produtoService.CadastrarProduto();
    }
}
